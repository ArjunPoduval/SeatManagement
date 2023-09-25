using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IReportCall
    {
        IEnumerable<SeatAllocationReportResponse> GenerateSeatAllocationReport(SeatAllocationReportRequest reportFilter);
    }
}
