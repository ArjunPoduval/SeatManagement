using MainAssessment.Tables;

namespace SeatManagementConsoleFrontend.Reports
{
    internal class ReportConsoleOutput
    {
        public static void SeatReportConsoleOutput(List<SeatAllocationReportResponse> reports)
        {
            if (reports?.Any() == true)
            {
                Console.WriteLine("Seats:\n");
                foreach (SeatAllocationReportResponse r in reports)
                {
                    string reportDataString = $"{r.CityAbbreviation}-{r.BuildingAbbreviation}-{r.Floor}-{r.FacilityName}-S{r.SeatNumber}";
                    if (r.EmployeeId > 0)
                    {
                        reportDataString += $"EmployeeName:{r.EmployeeName} EmployeeId:{r.EmployeeId}";
                    }
                    Console.WriteLine(reportDataString);
                }
            }
            else
            {
                Console.WriteLine("No Seats");
            }
        }

    }
}
