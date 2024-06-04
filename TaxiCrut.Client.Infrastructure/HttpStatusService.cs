using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiCrut.Infrastructure;

namespace TaxiCrut.Client.Infrastructure
{
    public class HttpStatusService : HttpBaseService
    {
        public HttpStatusService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<StatusModel>> GetStatusesAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<StatusModel>>("/api/statuses");
        }

        public async Task<StatusModel> GetStatusAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<StatusModel>($"/api/statuses/{id}");
        }

        public async Task<Guid> CreateStatusAsync(StatusCreate status)
        {
            var response = await httpClient.PostAsJsonAsync("/api/statuses", status);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateStatusAsync(StatusUpdate status)
        {
            await httpClient.PutAsJsonAsync($"/api/statuses/{status.Id}", status);
        }

        public async Task DeleteStatusAsync(Guid id)
        {
            await httpClient.DeleteAsync($"/api/statuses/{id}");
        }
    }
}
