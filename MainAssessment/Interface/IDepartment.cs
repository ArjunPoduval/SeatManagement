using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(DepartmentCreationDTO newDepartment);
        void RemoveDepartment(int DepId);
    }
}
