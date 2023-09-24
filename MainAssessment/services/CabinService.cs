using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainAssessment.services
{
    public class CabinService : ICabin
    {
        private readonly IRepository<Cabin> _cabinRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public CabinService(
            IRepository<Cabin> cabinTableRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Facility> facilityRepository)
        {
            _cabinRepository = cabinTableRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<Cabin> GetAllCabins()
        {
            return _cabinRepository.GetAll();
        }

        public void AddCabin(CabinTableDTO cabinTableDTO)
        {
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == cabinTableDTO.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            //check if the cabin already exist
            if (_cabinRepository.GetAll().Any(s => s.FacilityId == cabinTableDTO.FacilityId && s.CabinNumber == cabinTableDTO.CabinNumber))
            {
                throw new ObjectAlreadyExistException();
            }

            var item = new Cabin()
            {
                FacilityId = cabinTableDTO.FacilityId,
                CabinNumber = cabinTableDTO.CabinNumber
            };
            _cabinRepository.Add(item);
            _cabinRepository.Save();
        }

        public void UpdateCabinDetail(int cabinId, int? employeeId)
        {
            
            // Check if the cabin exists
            var cabin = _cabinRepository.GetAll()
                .FirstOrDefault(c => c.CabinId == cabinId);

            if (cabin == null)
            {
                throw new Exception("The Cabin does not exist.");
            }
            //if its occupied
            if (cabin.EmployeeId != null && employeeId!= null)
            {
                throw new Exception("Already occupied by an employee");
            }
            if (cabin.EmployeeId == null && employeeId == null)
            {
                throw new Exception("Already unallocated");
            }

            //employee is not already allocated another seat.
            if (_employeeRepository.GetAll().Any(c => c.EmployeeId == employeeId && c.IsAllocated == true))
            {
                throw new Exception("Employee is already allocated");
            }


            if (employeeId.HasValue)
            {
                var employee = _employeeRepository.GetById(employeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = true;
                    _employeeRepository.Update(employee);
                }
                else
                {
                    throw new Exception("Employee doen't Exist");
                }
            }
            if (employeeId==null)
            {
                var employee = _employeeRepository.GetById(cabin.EmployeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = false;
                    _employeeRepository.Update(employee);
                }
            }


            // Set EmployeeId in CabinTable and isallocated in Employee table
            cabin.EmployeeId = employeeId;
            _cabinRepository.Update(cabin);
            _cabinRepository.Save();
        }


        public void RemoveCabin(int cabinId)
        {
            var cabin = _cabinRepository.GetById(cabinId);
            if (cabin == null)
            {
                throw new Exception("The Cabin record does not exist.");
            }
            else
            {
                _cabinRepository.Remove(cabin);
                _cabinRepository.Save();
            }
        }
    }
}
