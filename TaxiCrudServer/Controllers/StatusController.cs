using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoryes;
using Repositoryes.Statuses;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Autos;
using TaxiCrut.Infrastructure;

namespace TaxiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStatusRepository _statusRepository;
        public StatusController(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAdvertsAsync()
        {
            var obj = _mapper.Map<List<StatusModel>>(await _statusRepository.GetAllAsync());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(obj);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAdvertAsync(StatusCreate StatusCreate)
        {
            var obj = _mapper.Map<Status>(StatusCreate);

            await _statusRepository.CreateAsync(obj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _statusRepository.GetAsync(id);
            if (obj is null)
                return BadRequest("obj not found");

            await _statusRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, StatusUpdate objUpdate)
        {
            var existingobj = await _statusRepository.GetAsync(id);
            if (existingobj is null)
                return NotFound("Education not found");

            _mapper.Map(objUpdate, existingobj);

            await _statusRepository.UpdateAsync(existingobj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Education {existingobj.Id} updated");
        }
    }
}
