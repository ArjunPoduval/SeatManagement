using MainAssessment.DTO;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface IDepartment
    {
        IEnumerable<Department> GetAll();
        void AddDepartment(string department);
        void RemoveDepartment(int DepId);
    }
}
