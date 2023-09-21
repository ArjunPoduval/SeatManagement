using MainAssessment.Tables;
using System.ComponentModel.DataAnnotations.Schema;

namespace MainAssessment.DTO
{
    public class EmployeeDTO
    {
        public string EmployeeName { get; set; }

        public int DepartmentId { get; set; }
    }
}
