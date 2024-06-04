using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiCrut.Infrastructure;

namespace TaxiCrut.Client.Infrastructure
{
    public class HttpAutoService : HttpBaseService
    {
        public HttpAutoService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<AutoModel>> GetAutosAsync()
        {
            try
            {
                return await httpClient.GetFromJsonAsync<IEnumerable<AutoModel>>("/api/auto/list");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching autos: {ex.Message}");
                return new List<AutoModel>();
            }
        }

        public async Task<AutoModel> GetAutoAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<AutoModel>($"/api/auto/{id}");
        }

        public async Task<Guid> CreateAutoAsync(AutoCreate auto)
        {
            var response = await httpClient.PostAsJsonAsync("/api/auto/add", auto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateAutoAsync(AutoUpdate auto)
        {
            var response = await httpClient.PutAsJsonAsync($"/api/auto/update/{auto.Id}", auto);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAutoAsync(Guid id)
        {
            var response = await httpClient.DeleteAsync($"/api/auto/delete/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
