using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

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
            try
            {
                facilityService.AddFacility(facilityDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{facilityId}")]
        public async Task<IActionResult> DeleteFacility(int FacilityId)
        {
            try
            {
                facilityService.RemoveFacility(FacilityId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
