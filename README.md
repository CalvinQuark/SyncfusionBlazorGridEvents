# SyncfusionBlazorGridEvents

This .NET 8.0 Blazor WASM app is a playground for working with the *Syncfusion* `SfGrid` Blazor component. This project will help a developer quickly understand the Syncfusion *SfGrid* component's 92 events. Run this page locally and select some events to discover both the sequence of those events and the specific arguments passed to the event handlers.

Outputs are logged to the web browser developer tools *Console* tab.

Note that logging some combinations of events causes the code to *loop indefinitely* in response to user interactions (i.e., the web browser hangs). Therefore, event handlers are wired up at runtime when they are selected for output. But usually this issue is avoided by choosing a minimal set of relevant events to log for the discovery task at hand rather than by selecting all possible events.

The *Notification Type* value can be set for multiple *Grid Event* values simultaneously by selecting several rows in the left grid (i.e., the `GridEventsNotificationList` component) and pressing `F2`.

The `SubjectGrid` component (i.e., the right grid) is configured with some typical settings such filtering, paging, sorting, and grouping, etc. Events for those actions can be logged without further tweaks to the *SubjectGrid*. However, to capture other events such as exporting a PDF for example, the *SubjectGrid*'s initial configuration must be modified to trigger those events.

The app expects an `appsettings.json` file to be placed in the `wwwroot` folder which contains the `SyncfusionLicenseKey` value.

```json
{
    "SyncfusionLicenseKey": "... your key here ..."
}
```

It is set up this way merely to exclude the `appsettings.json` file (and thus the license key) from the public repository via `.gitignore`. Alternatively, you can configure the key in the `Program.cs` file directly.

```cs
HttpClient httpClient = new() { BaseAddress = new Uri(webAssemblyHostBuilder.HostEnvironment.BaseAddress) };
webAssemblyHostBuilder.Services.AddScoped(sp => httpClient);

HttpResponseMessage appSettingsResponseMessage = await httpClient.GetAsync("appsettings.json");
using Stream appSettingsStream = await appSettingsResponseMessage.Content.ReadAsStreamAsync();
webAssemblyHostBuilder.Configuration.AddJsonStream(appSettingsStream);
string? syncfusionLicenseKey = webAssemblyHostBuilder.Configuration["SyncfusionLicenseKey"];
SyncfusionLicenseProvider.RegisterLicense(licenseKey: syncfusionLicenseKey);
```

OR

```cs
SyncfusionLicenseProvider.RegisterLicense(licenseKey: "... your key here ...");
```