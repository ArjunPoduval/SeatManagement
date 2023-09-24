using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MainAssessment.services
{
    public class SeatReportService : IReportCall
    {

        private readonly IRepository<AllocatedSeat> _allocatedSeatReportRepository;
        private readonly IRepository<UnAllocatedSeat> _unallocatedSeatReportRepository;

        public SeatReportService(IRepository<AllocatedSeat> allocatedSeats, IRepository<UnAllocatedSeat> unallocatedSeats)
        {
            this._allocatedSeatReportRepository = allocatedSeats;
            this._unallocatedSeatReportRepository = unallocatedSeats;
        }

        public IEnumerable<AllocatedSeat> GetAllAllocatedSeats()
        {

            return _allocatedSeatReportRepository.GetAll();
        }

        public IEnumerable<UnAllocatedSeat> GetAllUnallocatedSeats()
        {

            return _unallocatedSeatReportRepository.GetAll();
        }

    }

}
