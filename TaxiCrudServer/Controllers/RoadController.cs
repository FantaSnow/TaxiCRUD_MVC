using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoryes;
using Repositoryes.Orders;
using Repositoryes.Roads;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Autos;
using TaxiCrut.Infrastructure;

namespace TaxiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoadController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRoadRepository _roadRepository;
        public RoadController(IRoadRepository roadRepository, IMapper mapper)
        {
            _roadRepository = roadRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAdvertsAsync()
        {
            var obj = _mapper.Map<List<RoadModel>>(await _roadRepository.GetAllAsync());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(obj);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAdvertAsync(RoadCreate RoadCreate)
        {
            var obj = _mapper.Map<Road>(RoadCreate);

            await _roadRepository.CreateAsync(obj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _roadRepository.GetAsync(id);
            if (obj is null)
                return BadRequest("obj not found");

            await _roadRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, RoadUpdate objUpdate)
        {
            var existingobj = await _roadRepository.GetAsync(id);
            if (existingobj is null)
                return NotFound("Education not found");

            _mapper.Map(objUpdate, existingobj);

            await _roadRepository.UpdateAsync(existingobj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Education {existingobj.Id} updated");
        }
    }
}
