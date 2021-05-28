using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.Modal;
using JdShopsWebsite.Services;
using Microsoft.AspNetCore.Components.Authorization;

namespace JdShopsWebsite
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) }); 
            builder.Services.AddAuthentication();
            builder.Services.AddScoped<CustomAuthStateProvider>();
            builder.Services.AddScoped<CascadingAuthenticationState>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddBlazoredModal();
            var host = builder.Build();
            _ = new JwtPayload();
            await builder.Build().RunAsync();
        }
    }
}
