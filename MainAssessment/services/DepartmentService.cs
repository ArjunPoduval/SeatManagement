using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.services
{
    public class DepartmentService : IDepartment
    {
        private readonly IRepository<Department> repository;

        public DepartmentService(IRepository<Department> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Department> GetAll()
        {
            return repository.GetAll();
        }

        public void AddDepartment(string departmentname)
        {
        //Validation
            var departmentcreation = repository.GetAll().FirstOrDefault(c => c.DepartmentName == departmentname);
            if (departmentcreation != null)
            {
                throw new Exception("Similar Department already exist.");
            }
        //Creation
            var item = new Department()
            {
                DepartmentName = departmentname
            };
            repository.Add(item);
            repository.Save();
        }

        public void RemoveDepartment(int DepId)
        {
        //Validation
            var item = repository.GetById(DepId);
            if (item == null)
            {
                throw new Exception("The Department does not exist.");
            }
        //Removing
            else
            {
                repository.Remove(item);
                repository.Save();
            }
        }
    }
}
