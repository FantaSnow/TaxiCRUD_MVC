using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoryes;
using Repositoryes.Orders;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Autos;
using TaxiCrut.Infrastructure;

namespace TaxiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        public OrderController(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAdvertsAsync()
        {
            var obj = _mapper.Map<List<OrderModel>>(await _orderRepository.GetAllAsync());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(obj);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAdvertAsync(CityCreate OrderCreate)
        {
            var obj = _mapper.Map<Order>(OrderCreate);

            await _orderRepository.CreateAsync(obj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _orderRepository.GetAsync(id);
            if (obj is null)
                return BadRequest("obj not found");

            await _orderRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, OrderUpdate objUpdate)
        {
            var existingobj = await _orderRepository.GetAsync(id);
            if (existingobj is null)
                return NotFound("Education not found");

            _mapper.Map(objUpdate, existingobj);

            await _orderRepository.UpdateAsync(existingobj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Education {existingobj.Id} updated");
        }
    }
}
