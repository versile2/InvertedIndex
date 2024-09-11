using Microsoft.EntityFrameworkCore;
using MudBlazor.Extensions;
using Serilog;
using Serilog.Events;
using Web.DAL.Data;
using Web.DAL.Interfaces;
using Web.DAL.Repository;
using Web.DAL.Services;
using Web.UI.Components;

var builder = WebApplication.CreateBuilder(args);

// Configure Serilog
builder.Host.UseSerilog((context, services, configuration) => configuration
    .ReadFrom.Configuration(context.Configuration)
    .ReadFrom.Services(services)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File(
        path: "Logs/applog-.log",
        rollingInterval: RollingInterval.Day,
        restrictedToMinimumLevel: LogEventLevel.Warning
    ));

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServicesWithExtensions(config =>
{
    config.SnackbarConfiguration.PositionClass = MudBlazor.Defaults.Classes.Position.TopRight;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.HideTransitionDuration = 0;
});

builder.Services.AddScoped<ILocalStorageService, LocalStorageService>();
builder.Services.AddDbContextFactory<AppDbContext>(cfg => cfg.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<INavigationRepository, NavigationRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IErrorService, ErrorService>();

// load Index Service as a singleton and let it start working in the background right away
builder.Services.AddSingleton<IndexService>();
builder.Services.AddSingleton<IIndexService>(sp => sp.GetRequiredService<IndexService>());
builder.Services.AddHostedService(sp => sp.GetRequiredService<IndexService>());

var app = builder.Build();

app.UseMudExtensions();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
