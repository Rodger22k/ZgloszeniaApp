using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using ZgloszeniaApp.Frontend.Services;
using ZgloszeniaApp.Frontend;
using Blazored.LocalStorage;
using Blazor.DownloadFileFast;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazorDownloadFile();


builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

// 4. Pobierz z pliku konfiguracyjnego "ApiBaseUrl" (zob. sekcjê 2: appsettings.json w wwwroot)
var apiBaseUrl = builder.Configuration["ApiBaseUrl"];

// Jeœli z jakiegoœ powodu jest null, ustaw domyœlnie na localhost lub adres z Azure
if (string.IsNullOrEmpty(apiBaseUrl))
{
    apiBaseUrl = "https://zgloszeniaapp-ewa7f0bmgcfvbhgh.polandcentral-01.azurewebsites.net/";
}

// 5. Rejestracja HttpClient z bazowym adresem z pliku konfiguracyjnego
builder.Services.AddScoped(sp =>
{
    var httpClient = new HttpClient { BaseAddress = new Uri(apiBaseUrl) };

    // Podpinamy HttpClient do CustomAuthenticationStateProvider, 
    // jeœli Twoja klasa u¿ywa go do autoryzacji/jwt
    var authProvider = sp.GetRequiredService<AuthenticationStateProvider>()
        as CustomAuthenticationStateProvider;
    authProvider.SetHttpClient(httpClient);

    return httpClient;
});

// 6. Zarejestrowanie ZgloszenieService
builder.Services.AddScoped<ZgloszenieService>();

await builder.Build().RunAsync();
