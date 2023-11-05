using Blazored.Toast;
using BlazorServerApp.Authentication;
using Google.Api;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Refit;

string credentialFileName = "blazorserverdb-firebase-adminsdk-d6ztc-72ee8cbfb5.json";
string CredentialPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config", credentialFileName);

string apiKey = "AIzaSyALssK6Mu1mg1C9F2L2c36m9GdhiIqvDaw";

string identityToolkitBaseUrl = "https://identitytoolkit.googleapis.com";
string secureTokenBaseUrl = "https://securetoken.googleapis.com/";

Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", CredentialPath);

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServerSideBlazor().AddCircuitOptions(option => { option.DetailedErrors = true; });

// Add services to the container.
builder.Services.AddAuthenticationCore();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<ProtectedSessionStorage>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();

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
