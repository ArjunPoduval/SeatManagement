using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;
using SeatManagementConsoleFrontend.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend
{
    internal class Allocate
    {
        public void AllocateEmployeeToSeat()
        {
            ISeatManagerAPI<SeatAllocationDTO> seatallocation = new SeatManagementAPICall<SeatAllocationDTO>("SeatTable");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");
            Report reporting = new Report();

            var availableEmployeelist = employeedata.GetData().Where(e=>e.IsAllocated==false).ToList();
            Console.WriteLine("\n<----- * Unallocated Employee's * ----->");
            if(availableEmployeelist != null)
            {
                foreach (var emp in availableEmployeelist)
                {
                    Console.WriteLine($"EmployeeId: {emp.EmployeeId} EmployeName: {emp.EmployeeName}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            
            else
            {
                Console.WriteLine("No Employee is available for allocation.");
            }

            reporting.unAllocatedreport();


            Console.WriteLine("Enter FacilityID: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter SeatNumber: ");
            int seatno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId: ");
            int employeeid = Convert.ToInt32(Console.ReadLine());

            var seatallocate = new SeatAllocationDTO
            {
                FacilityId = facilityid,
                SeatNumber = seatno,
                EmployeeId = employeeid
            };
            Console.WriteLine(seatallocation.Allocate(seatallocate));
        }

        public void AllocateEmployeeToCabin()
        {
            ISeatManagerAPI<CabinAllocationDTO> cabinallocation = new SeatManagementAPICall<CabinAllocationDTO>("CabinTable");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");
            ISeatManagerAPI<Cabin> cabindata = new SeatManagementAPICall<Cabin>("CabinTable");

            var availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == false).ToList();
            Console.WriteLine("\n<----- * Unallocated Employee's * ----->");
            if (availableEmployeelist != null)
            {
                foreach (var emp in availableEmployeelist)
                {
                    Console.WriteLine($"EmployeeId: {emp.EmployeeId} EmployeName: {emp.EmployeeName}");
                }
                Console.WriteLine("<----- * ----->\n");
            }

            var cabinlist = cabindata.GetData().Where(e => e.EmployeeId==null).ToList();
            Console.WriteLine("\n<----- * Available Cabin * ----->");
            if (cabinlist != null)
            {
                foreach (var cabin in cabinlist)
                {
                    Console.WriteLine($"Facility Id: {cabin.FacilityId} Cabin Number: {cabin.CabinNumber}");
                }
                Console.WriteLine("<----- * ----->\n");
            }


            Console.WriteLine("Enter FacilityID: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cabin number: ");
            int cabinno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId: ");
            int employeeid = Convert.ToInt32(Console.ReadLine());

            var cabinallocate = new CabinAllocationDTO
            {
                FacilityId = facilityid,
                CabinNumber = cabinno,
                EmployeeId = employeeid
            };
            Console.WriteLine(cabinallocation.Allocate(cabinallocate));
        }

        public void AllocateAssettoMeetingroom()
        {

            ISeatManagerAPI<AssetsDTO> updateasset = new SeatManagementAPICall<AssetsDTO>("Assets");
            ISeatManagerAPI<MeetingRoomTable> meetingmanager = new SeatManagementAPICall<MeetingRoomTable>("Meetingroom");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            var assets = updateasset.GetData().Where(a=>a.MeetingRoomId==null);

            Console.WriteLine("<----- Available Assets ---->");

            foreach (var a in assets)
            {
                Console.WriteLine($"Asset Id: {a.AssetId}, FacilityId: {a.FacilityId}");
            }
            Console.WriteLine("<----- * ---->");

            var meetingroom = meetingmanager.GetData();

            Console.WriteLine("<----- Available MeetingRooms ---->");

            foreach (var a in meetingroom)
            {
                Console.WriteLine($"Meetingroom Id: {a.MeetingRoomId}, FacilityId: {a.FacilityId}, Meetingroom Number: {a.MeetingRoomNumber}");
            }
            Console.WriteLine("<----- * ---->");

            var Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (var f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter Facility Id: ");
            int facilityId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter AssetId: ");
            int Assetid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter MeetingroomId: ");
            int meetingid = Convert.ToInt32(Console.ReadLine());


            var asset = new AssetsDTO
            {
                FacilityId = facilityId,
                AssetId = Assetid,
                MeetingRoomId = meetingid

            };
            Console.WriteLine(updateasset.Allocate(asset));

        }
    }
}
