using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class AllocatedService : IReportCall
    {

        private readonly IRepository<AllocatedSeat> allocatedSeats;
        private readonly IRepository<UnAllocatedSeat> unallocatedSeats;

        public AllocatedService(IRepository<AllocatedSeat> allocatedSeats, IRepository<UnAllocatedSeat> unallocatedSeats)
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
