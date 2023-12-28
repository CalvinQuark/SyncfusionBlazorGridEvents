using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SyncfusionBlazorGridEvents;
using Syncfusion.Blazor;
using Syncfusion.Licensing;

WebAssemblyHostBuilder webAssemblyHostBuilder = WebAssemblyHostBuilder.CreateDefault(args);
webAssemblyHostBuilder.RootComponents.Add<App>("#app");
webAssemblyHostBuilder.RootComponents.Add<HeadOutlet>("head::after");

webAssemblyHostBuilder.Services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(webAssemblyHostBuilder.HostEnvironment.BaseAddress) });
webAssemblyHostBuilder.Services.AddSyncfusionBlazor();

HttpClient httpClient = new() { BaseAddress = new Uri(webAssemblyHostBuilder.HostEnvironment.BaseAddress) };
webAssemblyHostBuilder.Services.AddScoped(sp => httpClient);

HttpResponseMessage appSettingsResponseMessage = await httpClient.GetAsync("appsettings.json");
using Stream appSettingsStream = await appSettingsResponseMessage.Content.ReadAsStreamAsync();
webAssemblyHostBuilder.Configuration.AddJsonStream(appSettingsStream);
string? syncfusionLicenseKey = webAssemblyHostBuilder.Configuration["SyncfusionLicenseKey"];
SyncfusionLicenseProvider.RegisterLicense(licenseKey: syncfusionLicenseKey);

await webAssemblyHostBuilder.Build().RunAsync();
