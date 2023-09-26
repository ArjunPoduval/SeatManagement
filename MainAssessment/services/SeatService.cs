using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;


namespace MainAssessment.services
{
    public class SeatService : ISeat
    {
        private readonly IRepository<Seat> _seatRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public SeatService(
            IRepository<Seat> seatTableRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Facility> facilityRepository)
        {
            _seatRepository = seatTableRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<Seat> GetAllSeats()
        {
            //int pageNumber = 1;
            //int pageSize = 3;
            return _seatRepository.GetAll()
                //.Skip((2-1)*2)
                //.Take(2)
                ;
        }

        public void AddSeat(SeatDTO seatTable)
        {
            //validation
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == seatTable.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            //check if the seat already exist
            if (_seatRepository.GetAll().Any(s => s.FacilityId == seatTable.FacilityId && s.SeatNumber == seatTable.SeatNumber))
            {
                throw new ObjectAlreadyExistException();
            }
            //adding seat
            Seat item = new()
            {
                FacilityId = seatTable.FacilityId,
                SeatNumber = seatTable.SeatNumber
            };
            _seatRepository.Add(item);
            _seatRepository.Save();
        }

        public void UpdateSeatDetail(int seatId, int? employeeId)
        {
            //validation

            // Check if the seat exists
            Seat seat = _seatRepository.GetById(seatId);

            if (seat == null)
            {
                throw new Exception("The Seat does not exist.");
            }

            //check seat is already allocated
            if (seat.EmployeeId != null && employeeId != null)
            {
                throw new Exception("Already occupied by an employee");
            }
            if (seat.EmployeeId == null && employeeId == null)
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
                Employee employee = _employeeRepository.GetById(employeeId.Value);
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
            if (employeeId == null)
            {
                Employee employee = _employeeRepository.GetById(seat.EmployeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = false;
                    _employeeRepository.Update(employee);
                }
            }

            // Set EmployeeId in SeatTable and isallocated in Employee table
            seat.EmployeeId = employeeId;

            _seatRepository.Update(seat);
            _seatRepository.Save();
        }


        public void RemoveSeat(int seatId)
        {
            Seat seat = _seatRepository.GetById(seatId);
            if (seat == null)
            {
                throw new Exception("The Seat record does not exist.");
            }
            else
            {
                _seatRepository.Remove(seat);
                _seatRepository.Save();
            }
        }
    }
}
