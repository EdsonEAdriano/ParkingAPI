using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Post([FromBody] Company company)
        {
            try
            {
                await _companyRepository.add(company);
                _logger.LogTrace("Empresa adicionada.");
                return Ok(company);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while adding new company. ERROR MESSAGE: {e.Message}; ");
                return BadRequest(company);
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
        public async Task<IActionResult> Put([FromBody] Company company)
        {
            try
            {
                var companyEdit = await _companyRepository.edit(company);
                return Ok(companyEdit);
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
