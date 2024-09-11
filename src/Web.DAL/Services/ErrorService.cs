using Microsoft.EntityFrameworkCore;
using Web.DAL.Data;
using Web.DAL.Interfaces;
using Web.DAL.Models;

namespace Web.DAL.Services
{
    public class ErrorService : IErrorService
    {
        private readonly IDbContextFactory<AppDbContext> _dbContextFactory;
        public event EventHandler<ErrorChangeEventArgs>? ErrorChanged;

        public ErrorService(IDbContextFactory<AppDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
            using var context = _dbContextFactory.CreateDbContext();
            context.Initialize();
        }

        protected virtual void OnErrorChanged(ErrorChangeEventArgs e)
        {
            ErrorChanged?.Invoke(this, e);
        }

        public async Task<List<AppError>> GetApp_ErrorsAsync()
        {
            using var context = _dbContextFactory.CreateDbContext();
            return await context.AppErrors.Include(x => x.ErrorStatus).ToListAsync();
        }

        public async Task<OperationResult<AppError>> AddErrorAsync(AppError appError)
        {
            using var context = _dbContextFactory.CreateDbContext();
            bool isNewEntity = appError.ErrorId == 0;
            // Check if the error is a new entity
            if (isNewEntity)
            {
                // New entity, add it to the DbContext
                await context.AppErrors.AddAsync(appError);
            }
            else
            {
                return OperationResult<AppError>.FailureResult($"Error adding an App Error that already exists. {appError.ErrorId}", string.Empty);
            }

            try
            {
                // Save changes to the database
                int Id = await context.SaveChangesAsync();
                OnErrorChanged(new ErrorChangeEventArgs(
                    ChangeType.Added,
                    appError
                ));
                return OperationResult<AppError>.SuccessResult(appError, $"Successful add of {appError.Message}, Id: {Id}");
            }
            catch (DbUpdateException ex)
            {
                return OperationResult<AppError>.FailureResult($"Error adding/updating App Error: {ex.Message}", ex.StackTrace ?? string.Empty);
            }
        }

        public async Task<OperationResult<AppError>> EditErrorAsync(AppError appError)
        {
            using var context = _dbContextFactory.CreateDbContext();
            bool isNewEntity = appError.ErrorId == 0;
            // Check if the error is a new entity
            if (!isNewEntity)
            {
                // Edit entity
                // Attach existing entity if not tracked
                if (!context.AppErrors.Local.Any(e => e.ErrorId == appError.ErrorId))
                {
                    context.AppErrors.Attach(appError);
                    // Attach the updated entity to the DbContext and mark it as modified
                    context.Entry(appError).State = EntityState.Modified;
                }
            }
            else
            {
                return OperationResult<AppError>.FailureResult($"Error editing an App Error that doesn't exists. {appError.ErrorId}", string.Empty);
            }

            try
            {
                // Save changes to the database
                int Id = await context.SaveChangesAsync();
                OnErrorChanged(new ErrorChangeEventArgs(
                    ChangeType.Updated,
                    appError
                ));
                return OperationResult<AppError>.SuccessResult(appError, $"Successful update of {appError.Message}, Id: {Id}");
            }
            catch (DbUpdateException ex)
            {
                return OperationResult<AppError>.FailureResult($"Error adding/updating App Error: {ex.Message}", ex.StackTrace ?? string.Empty);
            }
        }
    }

    public class ErrorChangeEventArgs(ChangeType changeType, AppError appError) : EventArgs
    {
        public ChangeType ChangeType { get; } = changeType;
        public AppError AppError { get; } = appError;
    }
}
