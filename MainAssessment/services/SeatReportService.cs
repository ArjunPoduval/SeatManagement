using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MainAssessment.services
{
    public class SeatReportService : IReportCall
    {

        private readonly IRepository<AllocatedSeatsReport> _allocatedSeatReportRepository;
        private readonly IRepository<UnAllocatedSeatsReport> _unallocatedSeatReportRepository;

        public SeatReportService(IRepository<AllocatedSeatsReport> allocatedSeats, IRepository<UnAllocatedSeatsReport> unallocatedSeats)
        {
            this._allocatedSeatReportRepository = allocatedSeats;
            this._unallocatedSeatReportRepository = unallocatedSeats;
        }

        public IEnumerable<AllocatedSeatsReport> GetAllAllocatedSeats()
        {

            return _allocatedSeatReportRepository.GetAll();
        }

        public IEnumerable<UnAllocatedSeatsReport> GetAllUnallocatedSeats()
        {

            return _unallocatedSeatReportRepository.GetAll();
        }

    }

}
