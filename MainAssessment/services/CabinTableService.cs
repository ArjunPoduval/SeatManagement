using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainAssessment.services
{
    public class CabinTableService : ICabin
    {
        private readonly IRepository<CabinTable> _cabinTableRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public CabinTableService(
            IRepository<CabinTable> cabinTableRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Facility> facilityRepository)
        {
            _cabinTableRepository = cabinTableRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<CabinTable> GetAllCabins()
        {
            return _cabinTableRepository.GetAll();
        }

        public void AddCabin(CabinTableDTO cabinTableDTO)
        {
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == cabinTableDTO.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            //check if the cabin already exist
            if (_cabinTableRepository.GetAll().Any(s => s.FacilityId == cabinTableDTO.FacilityId && s.CabinNumber == cabinTableDTO.CabinNumber))
            {
                throw new Exception("This Facility already has that cabin number.");
            }

            var item = new CabinTable()
            {
                FacilityId = cabinTableDTO.FacilityId,
                CabinNumber = cabinTableDTO.CabinNumber
            };
            _cabinTableRepository.Add(item);
            _cabinTableRepository.Save();
        }

        public void AllocateEmployeeToCabin(CabinAllocationDTO cabinAllocationDTO)
        {
            
            // Check if the cabin exists
            var cabin = _cabinTableRepository.GetAll()
                .FirstOrDefault(c => c.FacilityId == cabinAllocationDTO.FacilityId && c.CabinNumber == cabinAllocationDTO.CabinNumber);

            if (cabin == null)
            {
                throw new Exception("The Cabin does not exist.");
            }
            //if its occupied
            if (cabin.EmployeeId != null)
            {
                throw new Exception("Already occupied by an employee");
            }

            if (!_employeeRepository.GetAll().Any(c => c.EmployeeId == cabinAllocationDTO.EmployeeId))
            {
                throw new Exception("Employee doesn't exist.");
            }
            //employee is not already allocated another seat.
            if (_employeeRepository.GetAll().Any(c => c.EmployeeId == cabinAllocationDTO.EmployeeId && c.IsAllocated == true))
            {
                throw new Exception("Employee is already allocated");
            }


            // Set EmployeeId in CabinTable and isallocated in Employee table
            cabin.EmployeeId = cabinAllocationDTO.EmployeeId;

            if (cabinAllocationDTO.EmployeeId.HasValue)
            {
                var employee = _employeeRepository.GetById(cabinAllocationDTO.EmployeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = true;
                    _employeeRepository.Update(employee);
                }
            }

            _cabinTableRepository.Update(cabin);
            _cabinTableRepository.Save();
        }

        public void DeallocateEmployeeFromCabin(CabinDeallocationDTO cabinDeallocationDTO)
        {
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == cabinDeallocationDTO.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }

            // Check if the cabin exists
            var cabin = _cabinTableRepository.GetAll()
                .FirstOrDefault(c => c.FacilityId == cabinDeallocationDTO.FacilityId && c.CabinNumber == cabinDeallocationDTO.CabinNumber);

            if (cabin == null)
            {
                throw new Exception("The Cabin does not exist.");
            }

            var employeeId = cabin.EmployeeId;
            cabin.EmployeeId = null;

            if (employeeId.HasValue)
            {
                var employee = _employeeRepository.GetById(employeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = false;
                    _employeeRepository.Update(employee);
                }
            }

            _cabinTableRepository.Update(cabin);
            _cabinTableRepository.Save();
        }

        public void RemoveCabin(int cabinId)
        {
            var cabin = _cabinTableRepository.GetById(cabinId);
            if (cabin == null)
            {
                throw new Exception("The Cabin record does not exist.");
            }
            else
            {
                _cabinTableRepository.Remove(cabin);
                _cabinTableRepository.Save();
            }
        }
    }
}
