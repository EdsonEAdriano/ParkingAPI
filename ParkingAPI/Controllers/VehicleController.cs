using Microsoft.AspNetCore.Mvc;
using ParkingAPI.DTOs;
using ParkingAPI.Helpers;
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
        public async Task<IActionResult> Post([FromBody] VehicleDTO vehicleDTO)
        {
            try
            {
                vehicleDTO.plate = vehicleDTO.plate.Trim();

                if (!Plate.validatePlate(vehicleDTO.plate))
                {
                    _logger.LogError($"Error while adding new vehicle. ERROR MESSAGE: Plate is not valid; ");
                    return BadRequest("Placa não é valida.");
                }

                if (! await _vehicleRepository.existsPlate(vehicleDTO.plate))
                {
                    _logger.LogError($"Error while adding new vehicle. ERROR MESSAGE: Plate already exists; ");
                    return BadRequest("Placa já existe.");
                }
               

                Vehicle vehicle = new Vehicle(vehicleDTO);

                await _vehicleRepository.add(vehicle);
                _logger.LogTrace("Veículo adicionado.");
                return Ok(vehicle);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while adding new vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest(vehicleDTO);
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
        [Route("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] VehicleDTO vehicleDTO)
        {
            try
            {
                Vehicle vehicle = await _vehicleRepository.get(id);

                if (vehicleDTO.plate != vehicle.plate)
                {
                    vehicleDTO.plate = vehicleDTO.plate.Trim();

                    if (!Plate.validatePlate(vehicleDTO.plate))
                    {
                        _logger.LogError($"Error while adding new vehicle. ERROR MESSAGE: Plate is not valid; ");
                        return BadRequest("Placa não é valida.");
                    }

                    if (await _vehicleRepository.existsPlate(vehicleDTO.plate))
                    {
                        _logger.LogError($"Error while updating vehicle. ERROR MESSAGE: Plate already exists; ");
                        return BadRequest("Placa já existe.");
                    }
                }

                                
                vehicle = new Vehicle(id, vehicleDTO);

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
                if (await _vehicleRepository.exists(id))
                {
                    var vehicle = await _vehicleRepository.remove(id);
                    return Ok(vehicle);
                }
                else {
                    _logger.LogError($"Error while removing vehicle. ERROR MESSAGE: Vehicle not exists; ");
                    return BadRequest($"Veículo não existe");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while removing vehicle. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while removing vehicle. ERROR MESSAGE: {e.Message}; ");
            }
        }
    }
}
