using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend.Reports
{
    internal class Report
    {
        public List<AllocatedSeatsReport> Allocatedreport()
        {
            ISeatManagerAPI<AllocatedSeatsReport> Allocatedreport = new SeatManagementAPICall<AllocatedSeatsReport>("Allocated");

            var report = Allocatedreport.GetData();

            return report;

        }
        public List<UnAllocatedSeatsReport> unAllocatedreport()
        {
            ISeatManagerAPI<UnAllocatedSeatsReport> Allocatedreport = new SeatManagementAPICall<UnAllocatedSeatsReport>("UnAllocated");
           
            var report = Allocatedreport.GetData();

            return report;
        }

    }
}
