using CSharp_Heroes.Models;
using CSharp_Poweres.Services;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Poweres.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class PowerController : ControllerBase
    {
        private readonly IPowerServices _powerServices;

        public PowerController(IPowerServices powerServices)
        {
            _powerServices = powerServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetPowers()
        {
            List<Power> result = await _powerServices.GetPowers();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetPowerById(int powerId)
        {
            var result = await _powerServices.GetPowerById(powerId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePower(Power entity)
        {
            try
            {
                var result = await _powerServices.CreatePower(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePower(Power entity)
        {
            try
            {
                var result = await _powerServices.UpdatePower(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePower(int powerId)
        {
            try
            {
                var result = await _powerServices.DeletePower(powerId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
