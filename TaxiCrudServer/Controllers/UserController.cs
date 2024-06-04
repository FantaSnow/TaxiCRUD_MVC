using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositoryes;
using Repositoryes.Users;
using TaxiCrudCore.Entities;
using TaxiCrudCore.Repositoryes.Autos;
using TaxiCrut.Infrastructure;

namespace TaxiCrudServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository UserRepository, IMapper mapper)
        {
            _userRepository = UserRepository;
            _mapper = mapper;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAdvertsAsync()
        {
            var obj = _mapper.Map<List<UserModel>>(await _userRepository.GetAllAsync());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(obj);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAdvertAsync(UserCreate UserCreate)
        {
            var obj = _mapper.Map<User>(UserCreate);

            await _userRepository.CreateAsync(obj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} added");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var obj = await _userRepository.GetAsync(id);
            if (obj is null)
                return BadRequest("obj not found");

            await _userRepository.DeleteAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"obj {obj.Id} deleted");
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, UserUpdate objUpdate)
        {
            var existingobj = await _userRepository.GetAsync(id);
            if (existingobj is null)
                return NotFound("Education not found");

            _mapper.Map(objUpdate, existingobj);

            await _userRepository.UpdateAsync(existingobj);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok($"Education {existingobj.Id} updated");
        }
    }
}
