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
        public List<AllocatedSeat> Allocatedreport()
        {
            ISeatManagerAPI<AllocatedSeat> Allocatedreport = new SeatManagementAPICall<AllocatedSeat>("Allocated");

            var report = Allocatedreport.GetData();

            return report;

        }
        public List<UnAllocatedSeat> unAllocatedreport()
        {
            ISeatManagerAPI<UnAllocatedSeat> Allocatedreport = new SeatManagementAPICall<UnAllocatedSeat>("UnAllocated");
           
            var report = Allocatedreport.GetData();

            return report;
        }

    }
}
