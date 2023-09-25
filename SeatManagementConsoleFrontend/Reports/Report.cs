using MainAssessment.DTO;
using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;

namespace SeatManagementConsoleFrontend.Reports
{
    internal class Report
    {
        private readonly ISeatManagerAPI<SeatAllocationReportResponse> seat = new SeatManagementAPICall<SeatAllocationReportResponse>("Seat");

        public List<SeatAllocationReportResponse> SeatReport(SeatAllocationReportRequest reportFilter)
        {
            return seat.GenerateReport(reportFilter);
        }
    }
}
