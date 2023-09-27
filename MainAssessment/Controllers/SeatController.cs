using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : Controller
    {
        private readonly ISeat _seatService;
        private readonly IReportCall _allocatedSeatReport;

        public SeatController(ISeat seatTableService, IReportCall allocated)
        {
            _seatService = seatTableService;
            _allocatedSeatReport = allocated;
        }

        [HttpGet]
        public IActionResult GetAllSeats()
        {
            return Ok(_seatService.GetAllSeats());
        }

        [HttpPost]
        public IActionResult CreateSeat(SeatDTO seatTableDTO)
        {
            _seatService.AddSeat(seatTableDTO);
            return Ok();
        }

        [HttpPatch]
        [Route("{seatId}")]
        public IActionResult UpdateSeatDetail([FromRoute] int seatId, int? employeeId)
        {
            try
            {
                _seatService.UpdateSeatDetail(seatId, employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteSeat(int id)
        {
            _seatService.RemoveSeat(id);
            return Ok();
        }

        [HttpPost("reports")]
        public IActionResult GenerateSeatAllocationReport(SeatAllocationReportRequest allocationFilterRequest)
        {
            return Ok(_allocatedSeatReport.GenerateSeatAllocationReport(allocationFilterRequest));
        }
    }
}
