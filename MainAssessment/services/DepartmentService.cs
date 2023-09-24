using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.services
{
    public class DepartmentService : IDepartment
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> repository)
        {
            this._departmentRepository = repository;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public void AddDepartment(DepartmentCreationDTO newDepartment)
        {
        //Validation
            var departmentcreation = _departmentRepository.GetAll().FirstOrDefault(c => c.DepartmentName == newDepartment.departmentName);
            if (departmentcreation != null)
            {
                throw new ObjectAlreadyExistException();
            }
        //Creation
            var item = new Department()
            {
                DepartmentName = newDepartment.departmentName
            };
            _departmentRepository.Add(item);
            _departmentRepository.Save();
        }

        public void RemoveDepartment(int DepId)
        {
        //Validation
            var item = _departmentRepository.GetById(DepId);
            if (item == null)
            {
                throw new ObjectDoNotExist();
            }
        //Removing
            else
            {
                _departmentRepository.Remove(item);
                _departmentRepository.Save();
            }
        }
    }
}
