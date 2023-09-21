using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;


namespace MainAssessment.services
{
    public class SeatTableService : ISeat
    {
        private readonly IRepository<SeatTable> _seatTableRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public SeatTableService(
            IRepository<SeatTable> seatTableRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Facility> facilityRepository)
        {
            _seatTableRepository = seatTableRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<SeatTable> GetAllSeats()
        {
            return _seatTableRepository.GetAll();
        }

        public void AddSeat(SeatTableDTO seatTable)
        {
        //validation
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == seatTable.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            //check if the seat already exist
            if (_seatTableRepository.GetAll().Any(s => s.FacilityId == seatTable.FacilityId && s.SeatNumber == seatTable.SeatNumber))
            {
                throw new Exception("This Facility already has that seat number.");
            }
        //adding seat
            var item = new SeatTable()
            {
                FacilityId = seatTable.FacilityId,
                SeatNumber = seatTable.SeatNumber
            };
            _seatTableRepository.Add(item);
            _seatTableRepository.Save();
        }

        public void AllocateEmployeeToSeat(SeatAllocationDTO seatAllocationDTO)
        {
        //validation

            // Check if the seat exists
            var seat = _seatTableRepository.GetAll()
                .FirstOrDefault(s => s.FacilityId == seatAllocationDTO.FacilityId && s.SeatNumber == seatAllocationDTO.SeatNumber);

            if (seat == null)
            {
                throw new Exception("The Seat does not exist.");
            }

            //check seat is already allocated
            if (seat.EmployeeId != null)
            {
                throw new Exception("Already occupied by an employee");
            }
            if (!_employeeRepository.GetAll().Any(c => c.EmployeeId == seatAllocationDTO.EmployeeId))
            {
                throw new Exception("Employee doesn't exist.");
            }
            //employee is not already allocated another seat.
            if (_employeeRepository.GetAll().Any(c => c.EmployeeId == seatAllocationDTO.EmployeeId && c.IsAllocated == true))
            {
                throw new Exception("Employee is already allocated");
            }


            // Set EmployeeId in SeatTable and isallocated in Employee table
            seat.EmployeeId = seatAllocationDTO.EmployeeId;

            if (seatAllocationDTO.EmployeeId.HasValue)
            {
                var employee = _employeeRepository.GetById(seatAllocationDTO.EmployeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = true;
                    _employeeRepository.Update(employee);
                }
            }

            _seatTableRepository.Update(seat);
            _seatTableRepository.Save();
        }

        public void DeallocateEmployeeFromSeat(SeatDeallocationDTO seatDeallocationDTO)
        {
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == seatDeallocationDTO.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }

            // Check if the seat exists
            var seat = _seatTableRepository.GetAll()
                .FirstOrDefault(s => s.FacilityId == seatDeallocationDTO.FacilityId && s.SeatNumber == seatDeallocationDTO.SeatNumber);

            if (seat == null)
            {
                throw new Exception("The Seat does not exist.");
            }

            var employeeId = seat.EmployeeId;
            seat.EmployeeId = null;

            if (employeeId.HasValue)
            {
                var employee = _employeeRepository.GetById(employeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = false;
                    _employeeRepository.Update(employee);
                }
            }
           

            _seatTableRepository.Update(seat);
            _seatTableRepository.Save();
        }
         
        public void RemoveSeat(int seatId)
        {
            var seat = _seatTableRepository.GetById(seatId);
            if (seat == null)
            {
                throw new Exception("The Seat record does not exist.");
            }
            else
            {
                _seatTableRepository.Remove(seat);
                _seatTableRepository.Save();
            }
        }
    }
}
