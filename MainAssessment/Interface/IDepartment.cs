using MainAssessment.DTO;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAllDepartments();
        void AddDepartment(DepartmentCreationDTO newDepartment);
        void RemoveDepartment(int DepId);
    }
}
