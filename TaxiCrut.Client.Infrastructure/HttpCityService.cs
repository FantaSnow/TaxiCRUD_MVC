using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiCrut.Infrastructure;

namespace TaxiCrut.Client.Infrastructure
{
    public class HttpCityService : HttpBaseService
    {
        public HttpCityService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<CityModel>> GetCitiesAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<CityModel>>("/api/cities");
        }

        public async Task<CityModel> GetCityAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<CityModel>($"/api/cities/{id}");
        }

        public async Task<Guid> CreateCityAsync(CityCreate city)
        {
            var response = await httpClient.PostAsJsonAsync("/api/cities", city);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateCityAsync(CityUpdate city)
        {
            await httpClient.PutAsJsonAsync($"/api/cities/{city.Id}", city);
        }

        public async Task DeleteCityAsync(Guid id)
        {
            await httpClient.DeleteAsync($"/api/cities/{id}");
        }
    }
}
