using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IReportCall
    {
        IEnumerable<SeatAllocationReportResponse> GenerateSeatAllocationReport(SeatAllocationReportRequest reportFilter);
        //IEnumerable<AllocatedSeatsReport> GetAllocatedSeats(SeatAllocationReportRequest reportFilter);
        //IEnumerable<UnAllocatedSeatsReport> GetAllUnAllocatedSeats(SeatAllocationReportRequest reportFilter);
    }
}
