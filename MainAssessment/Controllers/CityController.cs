using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.services;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace MainAssessment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CityController : Controller
    {
        private readonly ICity cityServices;

        public CityController(ICity repository)
        {
            this.cityServices = repository;
        }

        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(cityServices.GetAllCity());
        }

        [HttpPost]
        public IActionResult Create(CityLookupDTO cityLookupDTO)
        {
         
                cityServices.AddCity(cityLookupDTO);

                return Ok();
           
        }
        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int cityId)
        {
            try
            {
                cityServices.RemoveCity(cityId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPatch("Update")]
        public IActionResult Update(string cityName,CityLookupDTO updatedCityData)
        {
            try
            {
                cityServices.UpdateCity(cityName, updatedCityData);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
