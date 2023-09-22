using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IReportCall
    {
        IEnumerable<AllocatedSeat> GetAllAllocatedSeats();
        IEnumerable<UnAllocatedSeat> GetAllUnallocatedSeats();
    }
}
