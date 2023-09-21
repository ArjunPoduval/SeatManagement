using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.services;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;
using SeatManagementConsoleFrontend.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend
{
    internal class Onboarding
    {

        public void OnboardFacility()
        {
            
            ISeatManagerAPI<FacilityDTO> manager = new SeatManagementAPICall<FacilityDTO>("Facilities");
            ISeatManagerAPI<CityLookup> citymanager = new SeatManagementAPICall<CityLookup>("City");
            ISeatManagerAPI<Building> buildingmanager = new SeatManagementAPICall<Building>("Building");

            var citylist = citymanager.GetData();
            var buildinglist = buildingmanager.GetData();
            Console.WriteLine("\n<----- * Available Buildings * ----->");
            foreach (var building in buildinglist)
            {
                var cityname = building.CityId;
                Console.WriteLine($"BuildingId: {building.BuildingId} BuildingName: {building.BuildingName} CityId:{building.CityId} CityName:{(citylist.First(v=>v.CityId==building.CityId)).CityName}");
            }
            Console.WriteLine("<----- * ----->\n");


            Console.WriteLine("Enter BuildingId: ");
            int Buildingid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Floor: ");
            int floorno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Facility Name: ");
            string facilityname = Console.ReadLine();

            var item = new FacilityDTO
            {
                BuildingId = Buildingid,
                Floor = floorno,
                FacilityName = facilityname
            };

            Console.WriteLine(manager.CreateData(item));
        }
        public void OnboardSeats()
        {
            ISeatManagerAPI<SeatTableDTO> addseat = new SeatManagementAPICall<SeatTableDTO>("SeatTable");
            ISeatManagerAPI<SeatTable> seats = new SeatManagementAPICall<SeatTable>("SeatTable");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            var Facility = facilitymanager.GetData();

            Console.WriteLine("<----- Available Facility ---->");

            foreach (var f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());

            var seat = seats.GetData().Where(s=>s.FacilityId==facilityid);


            Console.WriteLine("<----- Already Onboarded seats in the facility ---->");

            foreach (var s in seat)
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
                var seatadd = new SeatTableDTO
                {
                    FacilityId = facilityid,
                    SeatNumber = seatno
                };
                seatno++;
                Console.WriteLine(addseat.CreateData(seatadd));
            }
            
        }

        public void OnboardMeetingroom()
        {
            ISeatManagerAPI<MeetingroomDTO> addmeetingroom = new SeatManagementAPICall<MeetingroomDTO>("Meetingroom");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");


            var Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (var f in Facility)
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

            var meetingroom = new MeetingroomDTO
            {
                FacilityId = facilityid,
                MeetingRoomNumber = meetingroomno,
                TotalSeats = totalseats
            };

            Console.WriteLine(addmeetingroom.CreateData(meetingroom));
        }

        public void OnboardCabin()
        {
            ISeatManagerAPI<CabinTableDTO> addcabin = new SeatManagementAPICall<CabinTableDTO>("CabinTable");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            var Facility = facilitymanager.GetData();


            Console.WriteLine("<----- Available Facility ---->");

            foreach (var f in Facility)
            {
                Console.WriteLine($"FacilityId: {f.FacilityId}, FacilityName: {f.FacilityName}");
            }
            Console.WriteLine("<----- * ---->");


            Console.WriteLine("Enter FacilityId: ");
            int facilityid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Cabin Number: ");
            int cabinno = Convert.ToInt32(Console.ReadLine());


            var cabin = new CabinTableDTO
            {
                FacilityId = facilityid,
                CabinNumber = cabinno
            };

            Console.WriteLine(addcabin.CreateData(cabin));
        }

        public void OnboardEmployee() 
        {
            ISeatManagerAPI<EmployeeDTO> addemployee = new SeatManagementAPICall<EmployeeDTO>("Employee");
            ISeatManagerAPI<Department> departmentmanager = new SeatManagementAPICall<Department>("Department");


            var department = departmentmanager.GetData();

            Console.WriteLine("<----- Available Departments ---->");

            foreach (var a in department)
            {
                Console.WriteLine($"DepartmentId: {a.DepartmentId}, DepartmentName: {a.DepartmentName}");
            }
            Console.WriteLine("<----- * ---->");

            Console.WriteLine("Enter Employee Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter DepartmentId: ");
            int departmentid = Convert.ToInt32(Console.ReadLine());

            var employee = new EmployeeDTO
            {
                EmployeeName = name,
                DepartmentId = departmentid
            };

            Console.WriteLine(addemployee.CreateData(employee));
        }

        public void OnboardAssets()
        {
            ISeatManagerAPI<AssetInsertionDTO> addasset = new SeatManagementAPICall<AssetInsertionDTO>("Assets");
            ISeatManagerAPI<AssetLookup> assetlookupmanager = new SeatManagementAPICall<AssetLookup>("AssetLookup");
            ISeatManagerAPI<Facility> facilitymanager = new SeatManagementAPICall<Facility>("Facilities");

            var assets = assetlookupmanager.GetData();

            Console.WriteLine("<----- Available Assets to Onboard ---->");

            foreach(var a in assets)
            {
                Console.WriteLine($"AssetId: {a.AssetId}, AssetName: {a.AssetName}");
            }
            Console.WriteLine("<----- * ---->");

            var Facility =facilitymanager.GetData();


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

            var asset = new AssetInsertionDTO
            {
                FacilityId = facilityId,
                AssetId = Assetid

            };

            Console.WriteLine(addasset.CreateData(asset));

        }
    }
}
