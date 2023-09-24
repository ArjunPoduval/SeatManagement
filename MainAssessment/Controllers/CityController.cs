using MainAssessment.CustomException;
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
        public IActionResult GetAllCity()
        {
            return Ok(cityServices.GetAllCity());
        }

        [HttpPost]
        public IActionResult CreateCity(CityDTO cityDTO)
        {
            try
            {
                cityServices.AddCity(cityDTO);
                return Ok();
            }
            catch(ObjectAlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
         
               
           
        }
        [HttpDelete]
        [Route("{cityId}")]
        public async Task<IActionResult> DeleteCity(int cityId)
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


    }
}
