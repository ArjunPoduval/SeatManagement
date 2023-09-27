using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartment departmentService;

        public DepartmentController(IDepartment departmentService)
        {
            this.departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult DepartmentDetails()
        {
            return Ok(departmentService.GetAllDepartments());
        }

        [HttpPost]
        public IActionResult CreateDepartment(DepartmentCreationDTO newDepartment)
        {
            departmentService.AddDepartment(newDepartment);
            return Ok();
        }

        [HttpDelete]
        [Route("{depId}")]
        public async Task<IActionResult> DeleteDepartment(int depId)
        {
            departmentService.RemoveDepartment(depId);
            return Ok();
        }
    }
}
