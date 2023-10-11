using Blazored.Toast;
using BlazorServerApp.Authentication;
using BlazorServerAppServices.Http;
using BlazorServerAppServices.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Refit;

string CredentialPath = "C:\\Users\\USUARIO\\source\\repos\\BlazorServerApp\\blazorserverdb-firebase-adminsdk-d6ztc-72ee8cbfb5.json";

string apiKey = "AIzaSyALssK6Mu1mg1C9F2L2c36m9GdhiIqvDaw";

string identityToolkitBaseUrl = "https://identitytoolkit.googleapis.com";
string secureTokenBaseUrl = "https://securetoken.googleapis.com/";

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

builder.Services.AddTransient<FirebaseApiKeyHttpMessageHandler>(s => new FirebaseApiKeyHttpMessageHandler());

builder.Services.AddRefitClient<IFirebaseRegisterService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(identityToolkitBaseUrl))
    .AddHttpMessageHandler<FirebaseApiKeyHttpMessageHandler>();
builder.Services.AddRefitClient<IFirebaseLoginService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(identityToolkitBaseUrl))
    .AddHttpMessageHandler<FirebaseApiKeyHttpMessageHandler>();
builder.Services.AddRefitClient<IFirebaseRefreshService>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(identityToolkitBaseUrl))
    .AddHttpMessageHandler<FirebaseApiKeyHttpMessageHandler>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
