using Microsoft.AspNetCore.Mvc;
using ParkingAPI.Models;
using ParkingAPI.Repositories;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<VehicleController> _logger;

        public VehicleController(IVehicleRepository vehicleRepository, ILogger<VehicleController> logger)
        {
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Vehicle vehicle)
        {
            try
            {
                await _vehicleRepository.add(vehicle);
                _logger.LogTrace("Veículo adicionado.");
                return Ok(vehicle);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while adding new vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest(vehicle);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companies = await _vehicleRepository.get();
                return Ok(companies);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while getting vehicle. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var vehicle = await _vehicleRepository.get(id);
                return Ok(vehicle);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while getting vehicle. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Vehicle vehicle)
        {
            try
            {
                var companyEdit = await _vehicleRepository.edit(vehicle);
                return Ok(companyEdit);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while updating vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while updating vehicle. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var vehicle = await _vehicleRepository.remove(id);
                return Ok(vehicle);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while removing vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while removing vehicle. ERROR MESSAGE: {e.Message}; ");
            }
        }
    }
}
