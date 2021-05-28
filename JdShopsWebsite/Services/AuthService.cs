using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using JdShopsWebsite;
using JdShopsWebsite.Shared;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;


namespace JdShopsWebsite.Services
{
    public interface IAuthService
    {
        Task<HttpResponseMessage> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }

    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        private readonly ILocalStorageService _localStorage;

        public AuthService(HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider,
            ILocalStorageService localStorage)
        {
            _httpClient = httpClient;
            _authenticationStateProvider = authenticationStateProvider;
            _localStorage = localStorage;
        }

        public async Task<HttpResponseMessage> Register(RegisterModel registerModel)
        {
            var result = await _httpClient.PostAsJsonAsync<RegisterModel>(
                "https://jdshops-api-app.azurewebsites.net/api/account/register", registerModel
                );
            
            return result;
        }

        public async Task<LoginResult> Login(LoginModel loginModel)
        {
            
            var response = await _httpClient.PostAsJsonAsync<LoginModel>("https://jdshops-api-app.azurewebsites.net/api/account/login", loginModel);

            var json = await response.Content.ReadAsStringAsync();
            var handler = new JwtSecurityTokenHandler();
            var tokenS = handler.ReadJwtToken(json);
            var loginResult = new LoginResult()
            {
                UserId= int.Parse(tokenS.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value),
                 Role= tokenS.Claims.First(c => c.Type == ClaimTypes.Role).Value,
                UserName = tokenS.Claims.First(c => c.Type == ClaimTypes.Name).Value, 
                IsSuccesfull = true

            };
            
            if (!response.IsSuccessStatusCode)
            {
                loginResult.IsSuccesfull = false;
                return loginResult ;
            }

            await _localStorage.SetItemAsync("authToken", json);
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(loginResult.UserName);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", json);

            
            return loginResult;
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            ((CustomAuthStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
