using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IReportCall
    {
        IEnumerable<AllocatedSeatsReport> GetAllAllocatedSeats();
        IEnumerable<UnAllocatedSeatsReport> GetAllUnallocatedSeats();
    }
}
