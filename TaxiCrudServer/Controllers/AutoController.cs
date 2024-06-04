using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxiCrudCore.Repositoryes;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Autos;
using TaxiCrut.Infrastructure;
namespace TaxiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IAutoRepository _autoRepository;
        private readonly IMapper _mapper;
        public AutoController(IAutoRepository autoRepository, IMapper mapper)
        {
            _autoRepository = autoRepository;
            _mapper = mapper;
        }
        [HttpGet("list")]
        public async Task<IActionResult> GetAllAdvertsAsync()
        {
            var education = _mapper.Map<List<AutoModel>>(await _autoRepository.GetAllAsync());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(education);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAdvertAsync(AutoCreate educationCreate)
        {
            var education = _mapper.Map<Auto>(educationCreate);

            await _autoRepository.CreateAsync(education);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"education {education.Id} added");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var education = await _autoRepository.GetAsync(id);
            if (education is null)
                return BadRequest("education not found");

            await _autoRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"education {education.Id} deleted");
        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, AutoUpdate educationUpdate)
        {
            var existingEducation = await _autoRepository.GetAsync(id);
            if (existingEducation is null)
                return NotFound("Education not found");

            _mapper.Map(educationUpdate, existingEducation);

            await _autoRepository.UpdateAsync(existingEducation);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Education {existingEducation.Id} updated");
        }
    }
}

