using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiCrut.Infrastructure;

namespace TaxiCrut.Client.Infrastructure
{
    public class HttpRoadService : HttpBaseService
    {
        public HttpRoadService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<RoadModel>> GetRoadsAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<RoadModel>>("/api/roads");
        }

        public async Task<RoadModel> GetRoadAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<RoadModel>($"/api/roads/{id}");
        }

        public async Task<Guid> CreateRoadAsync(RoadCreate road)
        {
            var response = await httpClient.PostAsJsonAsync("/api/roads", road);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateRoadAsync(RoadUpdate road)
        {
            await httpClient.PutAsJsonAsync($"/api/roads/{road.Id}", road);
        }

        public async Task DeleteRoadAsync(Guid id)
        {
            await httpClient.DeleteAsync($"/api/roads/{id}");
        }
    }
}
