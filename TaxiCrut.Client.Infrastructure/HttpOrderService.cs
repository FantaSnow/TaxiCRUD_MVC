using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TaxiCrut.Infrastructure;

namespace TaxiCrut.Client.Infrastructure
{
    public class HttpOrderService : HttpBaseService
    {
        public HttpOrderService(HttpClient httpClient) : base(httpClient) { }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<OrderModel>>("/api/orders");
        }

        public async Task<OrderModel> GetOrderAsync(Guid id)
        {
            return await httpClient.GetFromJsonAsync<OrderModel>($"/api/orders/{id}");
        }

        public async Task<Guid> CreateOrderAsync(CityCreate order)
        {
            var response = await httpClient.PostAsJsonAsync("/api/orders", order);
            return await response.Content.ReadFromJsonAsync<Guid>();
        }

        public async Task UpdateOrderAsync(OrderUpdate order)
        {
            await httpClient.PutAsJsonAsync($"/api/orders/{order.Id}", order);
        }

        public async Task DeleteOrderAsync(Guid id)
        {
            await httpClient.DeleteAsync($"/api/orders/{id}");
        }
    }
}
