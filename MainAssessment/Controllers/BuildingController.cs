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
            buildingService.AddBuilding(buildingDTO);
            return Ok();
        }

        [HttpDelete]
        [Route("{buildingId}")]
        public async Task<IActionResult> DeleteBuilding(int buildingId)
        {
            buildingService.RemoveBuilding(buildingId);
            return Ok();
        }
    }
}
