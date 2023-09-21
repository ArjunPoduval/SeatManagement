using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IAllocatedReportCall
    {
        IEnumerable<AllocatedSeat> GetAll();
    }
}
