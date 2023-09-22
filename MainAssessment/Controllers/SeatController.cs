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
        private readonly IReportCall _unallocated;
        private readonly IReportCall _allocated;

        public SeatController(ISeat seatTableService, IReportCall unallocated, IReportCall allocated)
        {
            _seatTableService = seatTableService;
            _unallocated = unallocated;
            _allocated = allocated;
        }

        [HttpGet]
        public IActionResult GetAllSeats()
        {
            return Ok(_seatTableService.GetAllSeats());
        }

        [HttpPost]
        public IActionResult CreateSeat(SeatTableDTO seatTableDTO)
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

        [HttpPatch("{seatID}")]
        public IActionResult UpdateSeatDetail(int seatId,int? employeeId)
        {
            try
            {
                _seatTableService.UpdateSeatDetail(seatId,employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> DeleteSeat(int id)
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

        [HttpPost("{allocationType}")]
        
        public IActionResult GenerateSeatAllocationReport(int allocationType,SeatAllocationReportRequest allocationFilterRequest)
        {
            if (allocationType == 1)
            {
                return Ok(_allocated.GetAllAllocatedSeats());
            }
            return Ok(_unallocated.GetAllUnallocatedSeats());

        }
    }
}
