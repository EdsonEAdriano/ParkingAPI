using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkingAPI.DTOs;
using ParkingAPI.Models;
using ParkingAPI.Repositories;

namespace ParkingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IPricesRepository _pricesRepository;
        private readonly ILogger<PriceController> _logger;
        public PriceController(IPricesRepository pricesRepository, ILogger<PriceController> logger)
        {
            _pricesRepository = pricesRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PricesDTO pricesDTO)
        {
            try
            {
                Prices price = new Prices(pricesDTO);
                await _pricesRepository.add(price);
                return Ok(price);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while adding prices. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while adding prices. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Prices> prices = await _pricesRepository.get();
                return Ok(prices);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while getting prices. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while getting prices. ERROR MESSAGE: {e.Message}; ");
            }  
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put(short id, [FromBody] PricesDTO pricesDTO)
        {
            try
            {
                Prices price = new Prices(id, pricesDTO);
                await _pricesRepository.update(price);
                return Ok(price);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while updating prices. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while updating prices. ERROR MESSAGE: {e.Message}; ");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(short id)
        {
            try
            {
                Prices price = await _pricesRepository.get(id);
                await _pricesRepository.delete(price);
                return Ok(price);
            }
            catch (Exception e)
            {
                _logger.LogError($"Error while updating prices. ERROR MESSAGE: {e.Message}; ");
                return BadRequest($"Error while updating prices. ERROR MESSAGE: {e.Message}; ");
            }
        }

    }
}
