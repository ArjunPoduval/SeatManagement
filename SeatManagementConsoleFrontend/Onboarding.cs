using MainAssessment.DTO;
using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;

namespace SeatManagementConsoleFrontend
{
    internal class Onboarding
    {

        public static void OnboardFacility()
        {

            ISeatManagerAPI<FacilityDTO> manager = new SeatManagementAPICall<FacilityDTO>("Facilities");
            ISeatManagerAPI<City> citymanager = new SeatManagementAPICall<City>("City");
            ISeatManagerAPI<Building> buildingmanager = new SeatManagementAPICall<Building>("Building");

            List<City> citylist = citymanager.GetData();
            List<Building> buildinglist = buildingmanager.GetData();
            Console.WriteLine("\n<----- * Available Buildings * ----->");
            foreach (Building building in buildinglist)
            {
                int cityname = building.CityId;
                Console.WriteLine($"BuildingId: {building.BuildingId} BuildingName: {building.BuildingName} CityId:{building.CityId} CityName:{(citylist.First(v => v.CityId == building.CityId)).CityName}");
            }
            Console.WriteLine("<----- * ----->\n");


            Console.WriteLine("Enter BuildingId: ");
            int Buildingid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Floor: ");
            int floorno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Facility Name: ");
            string facilityname = Console.ReadLine();

            FacilityDTO item = new()
            {
                BuildingId = Buildingid,
                Floor = floorno,
                FacilityName = facilityname
            };

            Console.WriteLine(manager.CreateData(item));
        }
        public static void OnboardSeats()
        {
            ISeatManagerAPI<SeatDTO> addseat = new SeatManagementAPICall<SeatDTO>("Seat");
            ISeatManagerAPI<Seat> seats = new SeatManagementAPICall<Seat>("Seat");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            List<Facility> Facility = facilitymanager.GetData();

            Console.WriteLine("<----- Available Facility ---->");

            foreach (Facility f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());

            IEnumerable<Seat> seat = seats.GetData().Where(s => s.FacilityId == facilityid);


            Console.WriteLine("<----- Already Onboarded seats in the facility ---->");

            foreach (Seat? s in seat)
            {
                Console.WriteLine($"seatId: {s.SeatId}, seatNumber: {s.SeatNumber}");
            }
            Console.WriteLine("<----- * ---->");

            Console.WriteLine("Number of seats to Onboard:");
            int numberofseats = Convert.ToInt32(Console.ReadLine());


            // Console.WriteLine("Enter Seat Number: ");
            //int seatno = Convert.ToInt32(Console.ReadLine());

            int seatno = seat.Count() + 1;
            for (int i = 0; i < numberofseats; i++)
            {
                SeatDTO seatadd = new()
                {
                    FacilityId = facilityid,
                    SeatNumber = seatno
                };
                seatno++;
                Console.WriteLine(addseat.CreateData(seatadd));
            }

        }

        public static void OnboardMeetingroom()
        {
            ISeatManagerAPI<MeetingroomDTO> addmeetingroom = new SeatManagementAPICall<MeetingroomDTO>("Meetingroom");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");


            List<Facility> Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (Facility f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");

            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Meeting Room Number: ");
            int meetingroomno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Total Seats: ");
            int totalseats = Convert.ToInt32(Console.ReadLine());

            MeetingroomDTO meetingroom = new()
            {
                FacilityId = facilityid,
                MeetingRoomNumber = meetingroomno,
                TotalSeats = totalseats
            };

            Console.WriteLine(addmeetingroom.CreateData(meetingroom));
        }

        public static void OnboardCabin()
        {
            ISeatManagerAPI<Cabin> cabins = new SeatManagementAPICall<Cabin>("Cabin");
            ISeatManagerAPI<CabinDTO> addcabin = new SeatManagementAPICall<CabinDTO>("Cabin");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            List<Facility> Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (Facility f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());

            IEnumerable<Cabin> cabinInFacility = cabins.GetData().Where(x => x.FacilityId == facilityid);

            Console.WriteLine("Enter Number of Cabins to onboard: ");
            int numberOfCabins = Convert.ToInt32(Console.ReadLine());

            int cabinno = cabinInFacility.Count() + 1;
            for (int i = 0; i < numberOfCabins; i++)
            {
                CabinDTO cabin = new()
                {
                    FacilityId = facilityid,
                    CabinNumber = cabinno
                };
                cabinno++;
                Console.WriteLine(addcabin.CreateData(cabin));
            }
        }

        public static void OnboardEmployee()
        {
            ISeatManagerAPI<EmployeeDTO> addemployee = new SeatManagementAPICall<EmployeeDTO>("Employee");
            ISeatManagerAPI<Department> departmentmanager = new SeatManagementAPICall<Department>("Department");


            List<Department> department = departmentmanager.GetData();

            Console.WriteLine("<----- Available Departments ---->");

            foreach (Department a in department)
            {
                Console.WriteLine($"DepartmentId: {a.DepartmentId}, DepartmentName: {a.DepartmentName}");
            }
            Console.WriteLine("<----- * ---->");

            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter DepartmentId: ");
            int departmentid = Convert.ToInt32(Console.ReadLine());

            EmployeeDTO employee = new()
            {
                EmployeeName = name,
                DepartmentId = departmentid
            };

            Console.WriteLine(addemployee.CreateData(employee));
        }

        public static void OnboardAssets()
        {
            ISeatManagerAPI<AssetCreationDTO> addasset = new SeatManagementAPICall<AssetCreationDTO>("Assets");
            ISeatManagerAPI<AssetType> assetlookupmanager = new SeatManagementAPICall<AssetType>("AssetType");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            List<AssetType> assets = assetlookupmanager.GetData();

            Console.WriteLine("<----- Available Assets to Onboard ---->");

            foreach (AssetType a in assets)
            {
                Console.WriteLine($"AssetId: {a.AssetId}, AssetName: {a.AssetName}");
            }
            Console.WriteLine("<----- * ---->");

            List<Facility> Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (Facility f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter Facility Id: ");
            int facilityId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter AssetId: ");
            int Assetid = Convert.ToInt32(Console.ReadLine());

            AssetCreationDTO asset = new()
            {
                FacilityId = facilityId,
                AssetId = Assetid

            };

            Console.WriteLine(addasset.CreateData(asset));

        }
    }
}
