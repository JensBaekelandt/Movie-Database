using BlazorWebAppMovies.Components;
using BlazorWebAppMovies.Sdk;
using BlazorWebAppMovies.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NuGet.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddQuickGridEntityFrameworkAdapter();

builder.Services.AddHttpClient("MovieApi", client =>
{
    var apiSettings = builder.Configuration.GetSection(nameof(ApiSettings)).Get<ApiSettings>();
    if (string.IsNullOrWhiteSpace(apiSettings?.BaseUrl))
    {
        throw new InvalidOperationException("ApiSettings:BaseUrl configuration is missing.");
    }
    client.BaseAddress = new Uri(apiSettings.BaseUrl);
});
// Add services to the container.

builder.Services.AddScoped<MovieSdkService>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseMigrationsEndPoint();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
