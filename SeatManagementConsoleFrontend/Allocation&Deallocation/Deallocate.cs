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
            ISeatManagerAPI<SeatDeallocationDTO> seatdeallocation = new SeatManagementAPICall<SeatDeallocationDTO>("SeatTable");
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


            Console.WriteLine("Enter FacilityID: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter SeatNumber: ");
            int seatno = Convert.ToInt32(Console.ReadLine());

            var seatdeallocate = new SeatDeallocationDTO
            {
                FacilityId = facilityid,
                SeatNumber = seatno
            };
            Console.WriteLine(seatdeallocation.Deallocate(seatdeallocate));
        }

        public void DeAllocateEmployeeinCabin()
        {
            ISeatManagerAPI<CabinDeallocationDTO> cabindeallocation = new SeatManagementAPICall<CabinDeallocationDTO>("CabinTable");
            ISeatManagerAPI<Cabin> cabindata = new SeatManagementAPICall<Cabin>("CabinTable");
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



            Console.WriteLine("Enter FacilityID: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cabin number: ");
            int cabinno = Convert.ToInt32(Console.ReadLine());

            var cabindeallocate = new CabinDeallocationDTO
            {
                FacilityId = facilityid,
                CabinNumber = cabinno
            };
            Console.WriteLine(cabindeallocation.Deallocate(cabindeallocate));
        }

        public void DeAllocateAssetFromMeetingroom()
        {
            ISeatManagerAPI<Assets> AssetData = new SeatManagementAPICall<Assets>("Assets");
            ISeatManagerAPI<AssetDeallocationDTO> AssetDeallocate = new SeatManagementAPICall<AssetDeallocationDTO>("Assets");

            var allAssets = AssetData.GetData().Where(a=> a.MeetingRoomId!=null).ToList();

            Console.WriteLine("\n<----- Allocated Assets ----->");
            if(allAssets!=null)
            {
                foreach (var asset in allAssets)
                {
                    Console.WriteLine($"AssetIndex: {asset.IndexId} FacilityId: {asset.FacilityId} AssetId: {asset.AssetId} MeetingRoomId: {asset.MeetingRoomId}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            else
            {
                Console.WriteLine("No Assets are available to DeAllocate");
            }

            Console.WriteLine("Enter IndexId to Deallocate: ");
            int indexDeallocateId = Convert.ToInt32(Console.ReadLine());

            var assettodeallocate = new AssetDeallocationDTO
            {
                IndexId = indexDeallocateId,
            };

            Console.WriteLine(AssetDeallocate.Deallocate(assettodeallocate));

        }

    }
}
