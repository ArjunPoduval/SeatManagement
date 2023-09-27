using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

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
            cityServices.AddCity(cityDTO);
            return Ok();
        }

        [HttpDelete]
        [Route("{cityId}")]
        public async Task<IActionResult> DeleteCity(int cityId)
        {
            cityServices.RemoveCity(cityId);

            return Ok();
        }
    }
}
