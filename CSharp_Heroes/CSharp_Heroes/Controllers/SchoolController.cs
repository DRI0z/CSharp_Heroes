using CSharp_Heroes.Models;
using CSharp_Heroes.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Heroes.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolServices _schoolServices;

        public SchoolController(ISchoolServices schoolServices)
        {
            _schoolServices = schoolServices;
        }

        [HttpGet]
        public async Task<IActionResult> GetSchools()
        {
            List<School> result = await _schoolServices.GetSchools();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetSchoolById(int schoolId)
        {
            var result = await _schoolServices.GetSchoolById(schoolId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSchool(School entity)
        {
            try
            {
                var result = await _schoolServices.CreateSchool(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSchool(School entity)
        {
            try
            {
                var result = await _schoolServices.UpdateSchool(entity);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSchool(int schoolId)
        {
            try
            {
                var result = await _schoolServices.DeleteSchool(schoolId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
