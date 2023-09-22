using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;


namespace MainAssessment.services
{
    public class SeatService : ISeat
    {
        private readonly IRepository<Seat> _seatTableRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public SeatService(
            IRepository<Seat> seatTableRepository,
            IRepository<Employee> employeeRepository,
            IRepository<Facility> facilityRepository)
        {
            _seatTableRepository = seatTableRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public IEnumerable<Seat> GetAllSeats()
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
            var item = new Seat()
            {
                FacilityId = seatTable.FacilityId,
                SeatNumber = seatTable.SeatNumber
            };
            _seatTableRepository.Add(item);
            _seatTableRepository.Save();
        }

        public void UpdateSeatDetail(int seatId, int? employeeId)
        {
        //validation

            // Check if the seat exists
            var seat = _seatTableRepository.GetById(seatId);

            if (seat == null)
            {
                throw new Exception("The Seat does not exist.");
            }

            //check seat is already allocated
            if (seat.EmployeeId != null && employeeId!= null)
            {
                throw new Exception("Already occupied by an employee");
            } 
            if (seat.EmployeeId == null && employeeId== null)
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
            if (employeeId == null)
            {
                var employee = _employeeRepository.GetById(seat.EmployeeId.Value);
                if (employee != null)
                {
                    employee.IsAllocated = false;
                    _employeeRepository.Update(employee);
                }
            }

            // Set EmployeeId in SeatTable and isallocated in Employee table
            seat.EmployeeId = employeeId;

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
