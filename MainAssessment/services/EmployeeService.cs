﻿using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class EmployeeService : IEmployee
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;

        public EmployeeService(IRepository<Employee> employeeRepository, IRepository<Department> departmentRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public void AddEmployee(EmployeeDTO employee)
        {
            //Validation
            Employee? employeecreaiton = _employeeRepository.GetAll().FirstOrDefault(c => c.EmployeeName == employee.EmployeeName);
            if (employeecreaiton != null)
            {
                throw new ObjectAlreadyExistException("Employee");
            }
            if (_departmentRepository.GetAll().FirstOrDefault(c => c.DepartmentId == employee.DepartmentId) == null)
            {
                throw new ObjectDoNotExist("Department");
            }
            //Creation
            Employee item = new()
            {
                EmployeeName = employee.EmployeeName,
                DepartmentId = employee.DepartmentId
            };
            _employeeRepository.Add(item);
            _employeeRepository.Save();
        }

        public void RemoveEmployee(int employeeId)
        {
            //Validation
            Employee employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                throw new ObjectDoNotExist("Employee");
            }
            //Removing
            else
            {
                _employeeRepository.Remove(employee);
                _employeeRepository.Save();
            }
        }

        public void UpdateEmployee(int employeeId, EmployeeDTO updatedEmployee)
        {
            //Validation


            Employee employee = _employeeRepository.GetById(employeeId);
            if (employee == null)
            {
                throw new ObjectDoNotExist("EMployee");
            }
            //department validaiton
            if (_departmentRepository.GetAll().FirstOrDefault(c => c.DepartmentId == updatedEmployee.DepartmentId) == null)
            {
                throw new ObjectDoNotExist("Department");
            }
            //validating user update
            if (_employeeRepository.GetAll().Any(m => m.EmployeeName == updatedEmployee.EmployeeName && m.DepartmentId == updatedEmployee.DepartmentId))
            {
                throw new Exception("updation terminated due to duplicate employee creation.");
            }
            // Update the employee's name with the new value
            employee.EmployeeName = updatedEmployee.EmployeeName;

            _employeeRepository.Update(employee);

            _employeeRepository.Save();
        }
    }
}
