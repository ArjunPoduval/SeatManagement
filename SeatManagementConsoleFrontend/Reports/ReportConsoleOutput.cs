using MainAssessment.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend.Reports
{
    internal class ReportConsoleOutput
    {
        public void AllocatedReportConsoleOutput(List<AllocatedSeatsReport>? reports)
        {
            if (reports.ToList().Count != 0)
            {

                Console.WriteLine("Allocated Seats:\n");
                foreach (var r in reports)
                {
                    Console.WriteLine($"{r.CityAbbreviation}-{r.BuildingAbbreviation}-{r.Floor}-{r.FacilityName}-S{r.SeatNumber} EmployeeName:{r.EmployeeName} EmployeeId:{r.EmployeeId}");
                }
            }
            else
            {
                Console.WriteLine("No Allocated Seats");
            }
        }
        public void UnAllocatedReportConsoleOutput(List<UnAllocatedSeatsReport>? reports)
        {
            if (reports.ToList().Count != 0)
            {

                Console.WriteLine("UnAllocated Seats:\n");
                foreach (var r in reports)
                {
                    Console.WriteLine($"{r.CityAbbreviation}-{r.BuildingAbbreviation}-{r.Floor}-{r.FacilityName}-S{r.SeatNumber}");
                }
            }
            else
            {
                Console.WriteLine("No UnAllocated Seats");
            }
        }
    }
}
