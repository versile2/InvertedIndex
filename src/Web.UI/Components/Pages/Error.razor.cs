using Microsoft.AspNetCore.Components;
using Web.DAL.Interfaces;

namespace Web.UI.Components.Pages
{
    public partial class Error
    {
        [Parameter]
        public Exception Exception { get; set; } = default!;

        [Inject]
        public IErrorService ErrorService { get; set; } = default!;

        private string _message = string.Empty;
        private string _stackTrace = string.Empty;

        protected override void OnAfterRender(bool firstRender)
        {
            if (firstRender)
            {
#if (DEBUG)
                if (Exception != null)
                {
                    _message = Exception.Message;
                    _stackTrace = Exception.StackTrace ?? string.Empty;
                }
#endif
                ErrorService.AddErrorAsync(new DAL.Models.AppError { ErrorStatusId = 1, Message = _message, Data = _stackTrace, LoggedBy = "DemoApp", Type = "Error" });
                StateHasChanged();
            }
        }

    }
}
