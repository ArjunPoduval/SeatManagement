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
            ISeatManagerAPI<Seat> seatallocation = new SeatManagementAPICall<Seat>("Seat");
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

            

            Console.WriteLine("Enter SeatId: ");
            int seatId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId: ");
            int? employeeid = Convert.ToInt32(Console.ReadLine());

            var allocatedData = new Seat
            {
                SeatId = seatId,
                EmployeeId = employeeid
            };
          
            Console.WriteLine(seatallocation.UpdateDetail(allocatedData));
        }

        public void AllocateEmployeeToCabin()
        {
            ISeatManagerAPI<Cabin> cabinallocation = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");
            ISeatManagerAPI<Cabin> cabindata = new SeatManagementAPICall<Cabin>("Cabin");

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


            Console.WriteLine("Enter cabin ID: ");
            int cabinId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId: ");
            int? employeeid = Convert.ToInt32(Console.ReadLine());

            var cabinallocate = new Cabin
            {
                CabinId = cabinId,
                EmployeeId = employeeid
            };
            Console.WriteLine(cabinallocation.UpdateDetail(cabinallocate));
        }

        public void AllocateAssettoMeetingroom()
        {

            ISeatManagerAPI<Assets> updateasset = new SeatManagementAPICall<Assets>("Assets");
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


            Console.WriteLine("Enter AssetIndex Id: ");
            int indexId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter MeetingroomId: ");
            int? meetingid = Convert.ToInt32(Console.ReadLine());


            var asset = new Assets
            {
                IndexId = indexId,
                MeetingRoomId = meetingid

            };
            Console.WriteLine(updateasset.UpdateDetail(asset));

        }
    }
}
