using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OzSozluk.Clients.BlazorWeb;
using OzSozluk.Clients.BlazorWeb.Infrastructure.Auth;
using OzSozluk.Clients.BlazorWeb.Infrastructure.Services;
using OzSozluk.Clients.BlazorWeb.Infrastructure.Services.Interfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


//projeye http client eklenmesi (multiple eklenebilir)
//var address = builder.Configuration["address"];
var address = "https://localhost:5001";
builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri(address);
})
.AddHttpMessageHandler<AuthTokenHandler>();

//IHttpClientFactory cagirilinca bize yukaridaki client verilecek
builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();

    return clientFactory.CreateClient("WebApiClient");
});

builder.Services.AddScoped<AuthTokenHandler>();

builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IVoteService, VoteService>();
builder.Services.AddTransient<IFavService, FavService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();

builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

builder.Services.AddBlazoredLocalStorage();

builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
