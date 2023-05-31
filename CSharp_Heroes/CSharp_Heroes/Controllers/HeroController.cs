using CSharp_Heroes.Models;
using CSharp_Heroes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Heroes.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class HeroController : ControllerBase
    {
        private readonly IHeroServices _heroServices;

        public HeroController(IHeroServices heroServices)
        {
            _heroServices = heroServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroes()
        {
            List<Hero> result = await _heroServices.GetHeroes();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetHeroById(int heroId)
        {
            var result = await _heroServices.GetHeroById(heroId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHero(Hero entity)
        {
            try
            {
                var result = await _heroServices.CreateHero(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHero(Hero entity)
        {
            try
            {
                var result = await _heroServices.UpdateHero(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHero(int heroId)
        {
            try
            {
                var result = await _heroServices.DeleteHero(heroId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
