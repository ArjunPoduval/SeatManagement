using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IUnAllocatedReportCall
    {
          IEnumerable<UnAllocatedSeat> GetAll();
    }
}
