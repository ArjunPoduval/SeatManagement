using MainAssessment.DTO;
using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;
using SeatManagementConsoleFrontend.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend
{
    internal class Deallocate
    {
        public void DeAllocateEmployeeinSeat()
        {
            ISeatManagerAPI<Seat> seatdeallocation = new SeatManagementAPICall<Seat>("Seat");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");
            Report reporting = new Report();

            var availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == true).ToList();
            Console.WriteLine("\n<----- * allocated Employee's * ----->");
            if (availableEmployeelist != null)
            {
                foreach (var emp in availableEmployeelist)
                {
                    Console.WriteLine($"EmployeeId: {emp.EmployeeId} EmployeName: {emp.EmployeeName}");
                }
                Console.WriteLine("<----- * ----->\n");
            }

            else
            {
                Console.WriteLine("No Employee is available for Deallocation.");
            }

            reporting.Allocatedreport();

            Console.WriteLine("Enter SeatId: ");
            int seatId = Convert.ToInt32(Console.ReadLine());

            var deallocatedData = new Seat
            {
                SeatId = seatId,
            };

            Console.WriteLine(seatdeallocation.UpdateDetail(deallocatedData));
        }

        public void DeAllocateEmployeeinCabin()
        {
            ISeatManagerAPI<Cabin> cabindeallocation = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<Cabin> cabindata = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");

            var cabinmembers = cabindata.GetData().Where(c=>c.EmployeeId!=null).ToList();   

            var availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == true).ToList();
            Console.WriteLine("\n<----- * allocated Employee's * ----->");
            if (availableEmployeelist != null)
            {
                foreach (var emp in availableEmployeelist)
                {
                    Console.WriteLine($"EmployeeId: {emp.EmployeeId} EmployeName: {emp.EmployeeName}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            else
            {
                Console.WriteLine("No Employee is available for Deallocation.");
            }


            Console.WriteLine("\n<----- * allocated Cabins * ----->");
            if (cabinmembers != null)
            {
                foreach (var cab in cabinmembers)
                {
                    Console.WriteLine($"FacilityId: {cab.FacilityId} CabinNumber: {cab.CabinNumber} EmployeeId: {cab.EmployeeId}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            else
            {
                Console.WriteLine("No Cabin is available for Deallocation.");
            }



            Console.WriteLine("Enter cabin ID: ");
            int cabinId = Convert.ToInt32(Console.ReadLine());

            var cabinallocate = new Cabin
            {
                CabinId = cabinId
            };
            Console.WriteLine(cabindeallocation.UpdateDetail(cabinallocate));
        }

        public void DeAllocateAssetFromMeetingroom()
        {
            ISeatManagerAPI<Assets> AssetData = new SeatManagementAPICall<Assets>("Assets");
            ISeatManagerAPI<Assets> AssetDeallocate = new SeatManagementAPICall<Assets>("Assets");

            var allAssets = AssetData.GetData().Where(a=> a.MeetingRoomId!=null).ToList();

            Console.WriteLine("\n<----- Allocated Assets ----->");
            if(allAssets!=null)
            {
                foreach (var assets in allAssets)
                {
                    Console.WriteLine($"AssetIndex: {assets.IndexId} FacilityId: {assets.FacilityId} AssetId: {assets.AssetId} MeetingRoomId: {assets.MeetingRoomId}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            else
            {
                Console.WriteLine("No Assets are available to DeAllocate");
            }


            Console.WriteLine("Enter AssetIndex Id: ");
            int indexId = Convert.ToInt32(Console.ReadLine());


            var asset = new Assets
            {
                IndexId = indexId,

            };
            Console.WriteLine(AssetDeallocate.UpdateDetail(asset));
        }

    }
}
