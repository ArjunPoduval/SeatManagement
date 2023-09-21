using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IEmployee
    {
        IEnumerable<Employee> GetAllEmployees();
        void AddEmployee(EmployeeDTO employee);
        void RemoveEmployee(int employeeId);
        void UpdateEmployee(int employeeId, EmployeeDTO updatedEmployee);
    }
}
