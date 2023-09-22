using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainAssessment.Controllers
{
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
            try
            {
                departmentService.AddDepartment(newDepartment);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{depId}")]
        public async Task<IActionResult> DeleteDepartment(int depId)
        {
            try
            {
                departmentService.RemoveDepartment(depId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
