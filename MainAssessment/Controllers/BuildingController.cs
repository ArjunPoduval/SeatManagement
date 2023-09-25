using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : Controller
    {
        private readonly IBuilding buildingService;
        public BuildingController(IBuilding buildingServices)
        {
            this.buildingService = buildingServices;
        }
        [HttpGet]
        public IActionResult GetAllBuildings()
        {
            return Ok(buildingService.GetAllBuildings());
        }

        [HttpPost]
        public IActionResult CreateBuilding(BuildingDTO buildingDTO)
        {
            try
            {
                buildingService.AddBuilding(buildingDTO);

                return Ok();
            }
            catch (ObjectAlreadyExistException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete]
        [Route("{buildingId}")]
        public async Task<IActionResult> DeleteBuilding(int buildingId)
        {
            try
            {
                buildingService.RemoveBuilding(buildingId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
