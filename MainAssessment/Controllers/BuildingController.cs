using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

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
        public IActionResult Index()
        {
            return Ok(buildingService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(BuildingDTO buildingDTO)
        {
            try
            {
                buildingService.AddBuilding(buildingDTO);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int BuildingId)
        {
            try
            {
                buildingService.RemoveBuilding(BuildingId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
