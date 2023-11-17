using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.DTOs;
using ParkingAPI.Models;
using ParkingAPI.Repositories;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControlController : ControllerBase
    {
        private readonly IControlRepository _controlRepository;

        public ControlController(IControlRepository controlRepository) 
        {
            _controlRepository = controlRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var controls = await _controlRepository.get();

            return Ok(controls);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var control =  await _controlRepository.get(id);

            return Ok(control);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ControlDTO controlDTO)
        {
            Control control = await _controlRepository.add(controlDTO);

            return Ok(control);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Exit(int id)
        {
            var control = await _controlRepository.exit(id);
            return Ok(control);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var control = await _controlRepository.remove(id);
            return Ok(control);
        }
    }
}
