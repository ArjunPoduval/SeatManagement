using MainAssessment.CustomException;
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
        private readonly ISeat _seatService;
        private readonly IReportCall _unallocatedSeatReport;
        private readonly IReportCall _allocatedSeatReport;

        public SeatController(ISeat seatTableService, IReportCall unallocated, IReportCall allocated)
        {
            _seatService = seatTableService;
            _unallocatedSeatReport = unallocated;
            _allocatedSeatReport = allocated;
        }

        [HttpGet]
        public IActionResult GetAllSeats()
        {
            return Ok(_seatService.GetAllSeats());
        }

        [HttpPost]
        public IActionResult CreateSeat(SeatTableDTO seatTableDTO)
        {
            try
            {
                _seatService.AddSeat(seatTableDTO);
                return Ok();
            }
            catch(ObjectAlreadyExistException ex) 
            { 
                return Conflict(ex.Message);
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
                _seatService.UpdateSeatDetail(seatId,employeeId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteSeat(int id)
        {
            try
            {
                _seatService.RemoveSeat(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("report")]
        
        public IActionResult GenerateSeatAllocationReport(int allocationType,SeatAllocationReportRequest allocationFilterRequest)
        {

            if (allocationType == 1)
            {
                return Ok(_allocatedSeatReport.GetAllAllocatedSeats());
            }
            return Ok(_unallocatedSeatReport.GetAllUnallocatedSeats());

        }
    }
}
