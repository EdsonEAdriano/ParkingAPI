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
        private readonly ICompanyRepository _companyRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly ILogger<ControlController> _logger;

        public ControlController(IControlRepository controlRepository, ILogger<ControlController> logger, ICompanyRepository companyRepository, IVehicleRepository vehicleRepository) 
        {
            _controlRepository = controlRepository;
            _companyRepository = companyRepository;
            _vehicleRepository = vehicleRepository;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var controls = await _controlRepository.get();

                return Ok(controls);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting control. ERROR MESSAGE: {e.Message}; ");
                return BadRequest("Erro ao coletar controles");
            }         
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var control = await _controlRepository.get(id);

                return Ok(control);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting control. ERROR MESSAGE: {e.Message}; ");
                return BadRequest("Erro ao coletar controles");
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Add(ControlDTO controlDTO)
        {
            try
            {
                if (!await _companyRepository.exists(controlDTO.companyID))
                {
                    _logger.LogError($"Error while adding control. ERROR MESSAGE: Vehicle do not exists; ");
                    return BadRequest("Veículo não existe");
                }
                else if (!await _vehicleRepository.exists(controlDTO.vehicleID))
                {
                    _logger.LogError($"Error while adding control. ERROR MESSAGE: Company do not exists; ");
                    return BadRequest("Empresa não existe");
                }

                if (!await _controlRepository.isParkedByDTO(controlDTO))
                {
                    Control control = await _controlRepository.add(controlDTO);

                    return Ok(control);
                }
                else
                {
                    _logger.LogError($"Error while adding control. ERROR MESSAGE: Vehicle is parked; ");
                    return BadRequest("Veículo já esta estacionado");
                }

                
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while adding control. ERROR MESSAGE: {e.Message}; ");
                return BadRequest("Erro ao adicionar controle");
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Exit(int id)
        {
            try
            {
                if (await _controlRepository.isParked(id))
                {
                    var control = await _controlRepository.exit(id);
                    return Ok(control);
                }
                else
                {
                    _logger.LogError($"Error while updating control. ERROR MESSAGE: Vehicle is not parked; ");
                    return BadRequest("Veículo não esta estacionado");
                }
            }
            catch (Exception e )
            {
                _logger.LogError($"Error while updating control. ERROR MESSAGE: {e.Message}; ");
                return BadRequest("Erro ao atualizar controle");
            }
            
            
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                if (await _controlRepository.exists(id))
                {
                    var control = await _controlRepository.remove(id);
                    return Ok(control);
                }
                else
                {
                    _logger.LogError($"Error while removing control. ERROR MESSAGE: Control do not exists; ");
                    return BadRequest("Controle não existe");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while removing control. ERROR MESSAGE: {e.Message}; ");
                return BadRequest("Erro ao remover controle");
            }
            
            
        }
    }
}
