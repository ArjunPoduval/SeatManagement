using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class SeatReportService : IReportCall
    {

        private readonly IRepository<AllocatedSeat> allocatedSeats;
        private readonly IRepository<UnAllocatedSeat> unallocatedSeats;

        public SeatReportService(IRepository<AllocatedSeat> allocatedSeats, IRepository<UnAllocatedSeat> unallocatedSeats)
        {
            this.allocatedSeats = allocatedSeats;
            this.unallocatedSeats = unallocatedSeats;
        }
        public IEnumerable<AllocatedSeat> GetAllAllocatedSeats()
        {

            return allocatedSeats.GetAll();
        }

        public IEnumerable<UnAllocatedSeat> GetAllUnallocatedSeats()
        {

            return unallocatedSeats.GetAll();
        }

    }

}
