using Web.DAL.Models;
using Web.DAL.Repository;

namespace Web.DAL.Interfaces
{
    public interface INavigationRepository
    {
        public Task<List<Data_NavLink>> GetNavigationMenuAsync();
        public Task<OperationResult<Data_NavLink>> AddUpdateNavLink(Data_NavLink navLink);
        public Task<OperationResult<Data_NavLink>> RemoveNavLink(int navLinkId);
        public event EventHandler<NavigationChangeEventArgs>? NavigationChanged;
    }
}
