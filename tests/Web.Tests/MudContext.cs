using Bunit;
using MudBlazor.Extensions;

namespace Web.Tests
{
    public class MudContext : TestContext
    {
        public MudContext()
        {
            // setup injected services
            // mudblazor required services
            JSInterop.Mode = JSRuntimeMode.Loose;
            Services.AddMudServicesWithExtensions(options =>
            {
                options.SnackbarConfiguration.ShowTransitionDuration = 0;
                options.SnackbarConfiguration.HideTransitionDuration = 0;
            });
        }
    }
}
