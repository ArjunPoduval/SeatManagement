using MainAssessment.DTO;
using MainAssessment.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MainAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IEmployee _employeeService;

        public EmployeeController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(_employeeService.GetAllEmployees());
        }

        [HttpPost]
        public IActionResult Create(EmployeeDTO employeeDTO)
        {
            try
            {
                _employeeService.AddEmployee(employeeDTO);
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
                _employeeService.RemoveEmployee(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPatch("Update")]
        public IActionResult Update(int id, EmployeeDTO updatedEmployee)
        {
            try
            {
                _employeeService.UpdateEmployee(id, updatedEmployee);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
