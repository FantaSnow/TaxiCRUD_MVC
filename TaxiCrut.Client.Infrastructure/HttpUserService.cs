using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiCrut.Infrastructure;

namespace TaxiCrut.Client.Infrastructure
{
    public class HttpUserService : HttpBaseService
    {
        public HttpUserService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<UserModel>> GetUsersAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<UserModel>>("/api/users");
        }

        public async Task<UserModel> GetUserAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<UserModel>($"/api/users/{id}");
        }

        public async Task<Guid> CreateUserAsync(UserCreate user)
        {
            var response = await httpClient.PostAsJsonAsync("/api/users", user);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateUserAsync(UserUpdate user)
        {
            await httpClient.PutAsJsonAsync($"/api/users/{user.Id}", user);
        }

        public async Task DeleteUserAsync(Guid id)
        {
            await httpClient.DeleteAsync($"/api/users/{id}");
        }
    }
}
