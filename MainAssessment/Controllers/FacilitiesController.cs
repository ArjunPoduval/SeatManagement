using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : Controller
    {
        private readonly IFacility facilityService;

        public FacilitiesController(IFacility facilityService)
        {
            this.facilityService = facilityService;
        }

        [HttpGet]
        public IActionResult GetAllFacility()
        {
            return Ok(facilityService.GetAll());
        }

        [HttpPost]
        public IActionResult CreateFacility(FacilityDTO facilityDTO)
        {
            facilityService.AddFacility(facilityDTO);
            return Ok();
        }

        [HttpDelete]
        [Route("{facilityId}")]
        public async Task<IActionResult> DeleteFacility(int FacilityId)
        {
            facilityService.RemoveFacility(FacilityId);
            return Ok();
        }
    }
}
