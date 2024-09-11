using Web.DAL.Models;
using Web.DAL.Services;

namespace Web.DAL.Interfaces
{
    public interface IErrorService
    {
        Task<List<AppError>> GetApp_ErrorsAsync();
        Task<OperationResult<AppError>> AddErrorAsync(AppError appError);
        Task<OperationResult<AppError>> EditErrorAsync(AppError appError);
        event EventHandler<ErrorChangeEventArgs>? ErrorChanged;
    }
}
