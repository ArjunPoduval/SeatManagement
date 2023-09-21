using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeat _seatTableService;

        public SeatController(ISeat seatTableService)
        {
            _seatTableService = seatTableService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_seatTableService.GetAllSeats());
        }

        [HttpPost]
        public IActionResult Create(SeatTableDTO seatTableDTO)
        {
            try
            {
                _seatTableService.AddSeat(seatTableDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Allocate")]
        public IActionResult AllocateEmployee(SeatAllocationDTO seatAllocationDTO)
        {
            try
            {
                _seatTableService.AllocateEmployeeToSeat(seatAllocationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Deallocate")]
        public IActionResult DeallocateEmployee(SeatDeallocationDTO seatDeallocationDTO)
        {
            try
            {
                _seatTableService.DeallocateEmployeeFromSeat(seatDeallocationDTO);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _seatTableService.RemoveSeat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
