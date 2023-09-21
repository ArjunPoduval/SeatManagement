using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : Controller
    {
        private readonly IUnAllocatedReportCall unallocated;
        private readonly IAllocatedReportCall allocated;

        public ReportController(IUnAllocatedReportCall _unallocated, IAllocatedReportCall _allocated)
        {
            this.unallocated = _unallocated;
            this.allocated = _allocated;
        }

        [HttpPost]
        public IActionResult GenerateSeatAllocationReport(SeatAllocationReportRequest allocationFilterRequest)
        {
            if (allocationFilterRequest.AllocationType == 1)
            {
                return Ok(allocated.GetAll()); 
            }
            return Ok(unallocated.GetAll());

        }
    }
}
