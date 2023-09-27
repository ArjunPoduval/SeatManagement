using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CabinController : ControllerBase
    {
        private readonly ICabin _cabinTableService;

        public CabinController(ICabin cabinTableService)
        {
            _cabinTableService = cabinTableService;
        }

        [HttpGet]
        public IActionResult GetAllCabins()
        {
            IEnumerable<Tables.Cabin> cabins = _cabinTableService.GetAllCabins();
            return Ok(cabins);
        }

        [HttpPost]
        public IActionResult AddCabin(CabinDTO cabinTableDTO)
        {
            _cabinTableService.AddCabin(cabinTableDTO);
            return Ok("Cabin added successfully.");
        }

        [HttpPatch]
        [Route("{cabinId}")]
        public IActionResult UpdateCabin(int cabinId, int? employeeId)
        {
            try
            {
                _cabinTableService.UpdateCabinDetail(cabinId, employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }


        [HttpDelete]
        [Route("{cabinId}")]
        public IActionResult RemoveCabin(int cabinId)
        {
            _cabinTableService.RemoveCabin(cabinId);
            return Ok("Cabin removed successfully.");
        }
    }
}
