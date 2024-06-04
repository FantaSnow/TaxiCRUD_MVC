using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repositoryes.Cityes;
using TaxiCrut.Infrastructure;

namespace TaxiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public CityController(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllCitiesAsync()
        {
            var cities = _mapper.Map<List<CityModel>>(await _cityRepository.GetAllAsync());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(cities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityByIdAsync(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city == null)
                return NotFound("City not found");

            return Ok(_mapper.Map<CityModel>(city));
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCityAsync(CityCreate cityCreate)
        {
            var city = _mapper.Map<City>(cityCreate);

            await _cityRepository.CreateAsync(city);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"City {city.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCityAsync(Guid id)
        {
            var city = await _cityRepository.GetAsync(id);
            if (city == null)
                return BadRequest("City not found");

            await _cityRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"City {city.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateCityAsync(Guid id, CityUpdate cityUpdate)
        {
            var existingCity = await _cityRepository.GetAsync(id);
            if (existingCity == null)
                return NotFound("City not found");

            _mapper.Map(cityUpdate, existingCity);

            await _cityRepository.UpdateAsync(existingCity);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"City {existingCity.Id} updated");
        }
    }
}
