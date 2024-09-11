using Microsoft.EntityFrameworkCore;
using Web.DAL.Data;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Repository
{
    public class NavigationRepository : INavigationRepository
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public event EventHandler<NavigationChangeEventArgs>? NavigationChanged;
        public NavigationRepository(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using var context = _dbContextFactory.CreateDbContext();
            context.Initialize();
        }

        protected virtual void OnNavigationChanged(NavigationChangeEventArgs e)
        {
            NavigationChanged?.Invoke(this, e);
        }

        public async Task<List<Data_NavLink>> GetNavigationMenuAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            var menuItems = await context.Data_NavLinks
                .OrderBy(m => !m.ParentId.HasValue ? int.MaxValue : m.ParentId) // Handle null ParentId which will ensure parent's are sorted by orderbyId
                .ThenBy(m => m.OrderById) // sort children by orderbyID
                .ToListAsync();
            return menuItems;
        }

        public async Task<OperationResult<Data_NavLink>> AddUpdateNavLink(Data_NavLink navLink)
        {
            using var _navigationDbContext = _dbContextFactory.CreateDbContext();
            bool isNewEntity = navLink.NavLinkId == 0;
            // Check if the navLink is a new entity
            if (isNewEntity)
            {
                // New entity, add it to the DbContext
                await _navigationDbContext.Data_NavLinks.AddAsync(navLink);
            }
            else
            {
                // Attach existing entity if not tracked
                if (!_navigationDbContext.Data_NavLinks.Local.Any(e => e.NavLinkId == navLink.NavLinkId))
                {
                    _navigationDbContext.Data_NavLinks.Attach(navLink);
                    // Attach the updated entity to the DbContext and mark it as modified
                    _navigationDbContext.Entry(navLink).State = EntityState.Modified;
                }
            }

            try
            {
                // Save changes to the database
                int Id = await _navigationDbContext.SaveChangesAsync();
                OnNavigationChanged(new NavigationChangeEventArgs(
                    isNewEntity ? ChangeType.Added : ChangeType.Updated,
                    navLink
                ));
                return OperationResult<Data_NavLink>.SuccessResult(navLink, $"Successful add/update of {navLink.Title}, Id: {Id}");
            }
            catch (DbUpdateException ex)
            {
                return OperationResult<Data_NavLink>.FailureResult($"Error adding/updating navigation link: {ex.Message}", ex.StackTrace ?? string.Empty);
            }
        }

        public async Task<OperationResult<Data_NavLink>> RemoveNavLink(int navLinkId)
        {
            using var _navigationDbContext = _dbContextFactory.CreateDbContext();

            try
            {
                // get entity and ensure valid then remove it 
                var entity = _navigationDbContext.Data_NavLinks.FirstOrDefault(x => x.NavLinkId == navLinkId)
                    ?? throw new Exception("Entity should not be null.");
                _navigationDbContext.Data_NavLinks.Remove(entity);
                // save changes
                await _navigationDbContext.SaveChangesAsync();
                OnNavigationChanged(new NavigationChangeEventArgs(ChangeType.Deleted, entity));
                return OperationResult<Data_NavLink>.SuccessResult(entity!, $"Successful deletion of {entity.Title}, Id: {navLinkId}");
            }
            catch (DbUpdateException ex)
            {
                return OperationResult<Data_NavLink>.FailureResult($"Error removing navigation link: {ex.Message}", ex.StackTrace ?? string.Empty);
            }
        }
    }
    public class NavigationChangeEventArgs(ChangeType changeType, Data_NavLink navLink) : EventArgs
    {
        public ChangeType ChangeType { get; } = changeType;
        public Data_NavLink NavLink { get; } = navLink;
    }
}
