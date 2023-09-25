using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;

namespace SeatManagementConsoleFrontend
{
    internal class Allocate
    {
        public static void AllocateEmployeeToSeat()
        {
            ISeatManagerAPI<Seat> seatallocation = new SeatManagementAPICall<Seat>("Seat");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");
            List<Seat> allAllocatedSeats = seatallocation.GetData().Where(s => s.EmployeeId == null).ToList();
            Console.WriteLine("\n<---- * UnAllocated Seats * ---->");
            if (allAllocatedSeats != null)
            {
                foreach (Seat? seat in allAllocatedSeats)
                {
                    Console.WriteLine($"SeatId: {seat.SeatId} FacilityId: {seat.FacilityId}");
                }
            }
            List<Employee> availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == false).ToList();
            Console.WriteLine("\n<----- * Unallocated Employee's * ----->");
            if (availableEmployeelist != null)
            {
                foreach (Employee? emp in availableEmployeelist)
                {
                    Console.WriteLine($"EmployeeId: {emp.EmployeeId} EmployeName: {emp.EmployeeName}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            else
            {
                Console.WriteLine("No Employee is available for allocation.");
            }


            Console.WriteLine("Enter SeatId: ");
            int seatId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId: ");
            int? employeeid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(seatallocation.UpdateDetail(seatId, employeeid));
        }

        public static void AllocateEmployeeToCabin()
        {
            ISeatManagerAPI<Cabin> cabinallocation = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");
            ISeatManagerAPI<Cabin> cabindata = new SeatManagementAPICall<Cabin>("Cabin");

            List<Employee> availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == false).ToList();
            Console.WriteLine("\n<----- * Unallocated Employee's * ----->");
            if (availableEmployeelist != null)
            {
                foreach (Employee? emp in availableEmployeelist)
                {
                    Console.WriteLine($"EmployeeId: {emp.EmployeeId} EmployeName: {emp.EmployeeName}");
                }
                Console.WriteLine("<----- * ----->\n");
            }

            List<Cabin> cabinlist = cabindata.GetData().Where(e => e.EmployeeId == null).ToList();
            Console.WriteLine("\n<----- * Available Cabin * ----->");
            if (cabinlist != null)
            {
                foreach (Cabin? cabin in cabinlist)
                {
                    Console.WriteLine($"CabinId: {cabin.CabinId} Facility Id: {cabin.FacilityId} Cabin Number: {cabin.CabinNumber}");
                }
                Console.WriteLine("<----- * ----->\n");
            }


            Console.WriteLine("Enter cabin ID: ");
            int cabinId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmployeeId: ");
            int? employeeid = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(cabinallocation.UpdateDetail(cabinId, employeeid));
        }

        public static void AllocateAssetToMeetingRoom()
        {

            ISeatManagerAPI<Assets> updateasset = new SeatManagementAPICall<Assets>("Assets");
            ISeatManagerAPI<MeetingRoom> meetingmanager = new SeatManagementAPICall<MeetingRoom>("Meetingroom");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            IEnumerable<Assets> assets = updateasset.GetData().Where(a => a.MeetingRoomId == null);

            Console.WriteLine("<----- Available Assets ---->");

            foreach (Assets? a in assets)
            {
                Console.WriteLine($"Asset IndexId: {a.IndexId}, FacilityId: {a.FacilityId}");
            }
            Console.WriteLine("<----- * ---->");

            List<MeetingRoom> meetingroom = meetingmanager.GetData();

            Console.WriteLine("<----- Available MeetingRooms ---->");

            foreach (MeetingRoom a in meetingroom)
            {
                Console.WriteLine($"Meetingroom Id: {a.MeetingRoomId}, FacilityId: {a.FacilityId}, Meetingroom Number: {a.MeetingRoomNumber}");
            }
            Console.WriteLine("<----- * ---->");

            List<Facility> Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (Facility f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter AssetIndex Id: ");
            int indexId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter MeetingroomId: ");
            int? meetingid = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine(updateasset.UpdateAssetDetail(indexId, meetingid));

        }
    }
}
