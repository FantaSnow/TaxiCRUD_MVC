using TaxiCrudClient;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using TaxiCrut.Client.Infrastructure;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<HttpAutoService>();
builder.Services.AddScoped<HttpCityService>();
builder.Services.AddScoped<HttpRoadService>();
builder.Services.AddScoped<HttpUserService>();
builder.Services.AddScoped<HttpStatusService>();
builder.Services.AddScoped<HttpOrderService>();

builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzcyOTI3QDMyMzAyZTMzMmUzMEtNUU81MmxwMmt5S1Mzd2ZjTkVFTlpNMmNvdCtJMGwzSlA5VFpDejYzeEk9");
    
await builder.Build().RunAsync();
