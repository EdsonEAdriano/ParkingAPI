using Microsoft.AspNetCore.Mvc;
using ParkingAPI.DTOs;
using ParkingAPI.Helpers;
using ParkingAPI.Models;
using ParkingAPI.Repositories;

namespace ParkingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly ILogger<CompanyController> _logger;

        public CompanyController(ICompanyRepository companyRepository, ILogger<CompanyController> logger)
        {
            _companyRepository = companyRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyDTO companyDTO)
        {
            try
            {
                if (!CNPJ.validateCNPJ(companyDTO.cnpj))
                {
                    _logger.LogError($"Error while adding new company. ERROR MESSAGE: CNPJ inválido; ");
                    return BadRequest("CNPJ inválido");
                }

                Company company = new Company(companyDTO);

                if (!await _companyRepository.existsCNPJ(company.cnpj))
                {
                    await _companyRepository.add(company);
                    _logger.LogTrace("Empresa adicionada.");
                    return Ok(company);
                }
                else
                {
                    _logger.LogError($"Error while adding new company. ERROR MESSAGE: CNPJ already exists; ");
                    return BadRequest("CNPJ já existe");
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while adding new company. ERROR MESSAGE: {e.Message}; ");
                return BadRequest(companyDTO);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var companies = await _companyRepository.get();
                return Ok(companies);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting company. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while getting company. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var company = await _companyRepository.get(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting company. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while getting company. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyDTO companyDTO)
        {
            try
            {
                if (!CNPJ.validateCNPJ(companyDTO.cnpj))
                {
                    _logger.LogError($"Error while adding new company. ERROR MESSAGE: CNPJ inválido; ");
                    return BadRequest("CNPJ inválido");
                }

                Company company = new Company(id, companyDTO);

                if (!await _companyRepository.existsCNPJ(company.cnpj))
                {
                    await _companyRepository.edit(company);
                    return Ok(companyDTO);
                }
                else
                {
                    _logger.LogError($"Error while adding new company. ERROR MESSAGE: CNPJ already exists; ");
                    return BadRequest("CNPJ já existe");
                }
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while updating company. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while updating company. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var company = await _companyRepository.remove(id);
                return Ok(company);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while removing company. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while removing company. ERROR MESSAGE: {e.Message}; ");
            }
        }
    }
}
