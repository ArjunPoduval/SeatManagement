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
        public IActionResult Index()
        {
            return Ok(departmentService.GetAll());
        }

        [HttpPost]
        public IActionResult Create(String departmentName)
        {
            try
            {
                departmentService.AddDepartment(departmentName);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int DepId)
        {
            try
            {
                departmentService.RemoveDepartment(DepId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
