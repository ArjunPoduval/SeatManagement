using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllocatedController : Controller
    {

        private readonly IAllocatedReportCall allocated;

        public AllocatedController(IAllocatedReportCall repository)
        {
            this.allocated = repository;
        }
        [HttpGet]
        public IActionResult GetDetails()
        {
            return Ok(allocated.GetAll());
        }
    }
}
