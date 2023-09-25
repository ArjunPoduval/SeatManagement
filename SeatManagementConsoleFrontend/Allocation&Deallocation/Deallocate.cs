using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;

namespace SeatManagementConsoleFrontend
{
    internal class Deallocate
    {
        public void DeAllocateEmployeeinSeat()
        {
            ISeatManagerAPI<Seat> seatdeallocation = new SeatManagementAPICall<Seat>("Seat");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");

            List<Seat> allAllocatedSeats = seatdeallocation.GetData().Where(s => s.EmployeeId != null).ToList();
            List<Employee> availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == true).ToList();
            Console.WriteLine("\n<---- * Allocated Seats * ---->");
            if (allAllocatedSeats != null)
            {
                foreach (Seat? seat in allAllocatedSeats)
                {
                    Console.WriteLine($"SeatId: {seat.SeatId} FacilityId: {seat.FacilityId}");
                }
            }
            Console.WriteLine("\n<----- * allocated Employee's * ----->");
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
                Console.WriteLine("No Employee is available for Deallocation.");
            }


            Console.WriteLine("Enter SeatId: ");
            int seatId = Convert.ToInt32(Console.ReadLine());

            int? id = null;

            Console.WriteLine(seatdeallocation.UpdateDetail(seatId, id));
        }

        public void DeAllocateEmployeeinCabin()
        {
            ISeatManagerAPI<Cabin> cabindeallocation = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<Cabin> cabindata = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<Employee> employeedata = new SeatManagementAPICall<Employee>("Employee");

            List<Cabin> cabinmembers = cabindata.GetData().Where(c => c.EmployeeId != null).ToList();

            List<Employee> availableEmployeelist = employeedata.GetData().Where(e => e.IsAllocated == true).ToList();
            Console.WriteLine("\n<----- * allocated Employee's * ----->");
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
                Console.WriteLine("No Employee is available for Deallocation.");
            }


            Console.WriteLine("\n<----- * allocated Cabins * ----->");
            if (cabinmembers != null)
            {
                foreach (Cabin? cab in cabinmembers)
                {
                    Console.WriteLine($"CabinId: {cab.CabinId} FacilityId: {cab.FacilityId} CabinNumber: {cab.CabinNumber} EmployeeId: {cab.EmployeeId}");
                }
                Console.WriteLine("<----- * ----->\n");
            }
            else
            {
                Console.WriteLine("No Cabin is available for Deallocation.");
            }



            Console.WriteLine("Enter cabin ID: ");
            int cabinId = Convert.ToInt32(Console.ReadLine());
            int? id = null;

            Console.WriteLine(cabindeallocation.UpdateDetail(cabinId, id));
        }

        public void DeAllocateAssetFromMeetingroom()
        {
            ISeatManagerAPI<Assets> AssetData = new SeatManagementAPICall<Assets>("Assets");
            ISeatManagerAPI<Assets> AssetDeallocate = new SeatManagementAPICall<Assets>("Assets");

            List<Assets> allAssets = AssetData.GetData().Where(a => a.MeetingRoomId != null).ToList();

            Console.WriteLine("\n<----- Allocated Assets ----->");
            if (allAssets != null)
            {
                foreach (Assets? assets in allAssets)
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

            int? id = null;
            Console.WriteLine(AssetDeallocate.UpdateDetail(indexId, id));
        }

    }
}
