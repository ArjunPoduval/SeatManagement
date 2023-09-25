using MainAssessment.DTO;
using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;
using SeatManagementConsoleFrontend.Reports;

namespace SeatManagementConsoleFrontend.Filters
{
    internal class SeatReportFiltering
    {
        private readonly ISeatManagerAPI<Building> buildings = new SeatManagementAPICall<Building>("Building");
        private readonly ISeatManagerAPI<City> city = new SeatManagementAPICall<City>("City");
        private readonly ISeatManagerAPI<Facility> facility = new SeatManagementAPICall<Facility>("Facility");
        private readonly Report report = new();
        private readonly ReportConsoleOutput output = new();

        public void ApplyBuildingFilter(SeatAllocationReportRequest filter)
        {
            IEnumerable<Building> buildinglist = buildings.GetData().Where(b => b.CityId == filter.CityId);

            foreach (Building? b in buildinglist)
            {
                Console.WriteLine($"BuildingId: {b.BuildingId} - BuildingName:{b.BuildingName}");
            }
            Console.WriteLine("Enter Building Id to filter:");
            int buildInput = Convert.ToInt32(Console.ReadLine());

            Building? filteredBuilding = buildinglist.FirstOrDefault(b => b.BuildingId == buildInput);

            if (filteredBuilding is null)
            {
                Console.WriteLine("Enter Valid BuildingId");
            }
            else
            {
                filter.BuildingId = buildInput;
                Console.WriteLine("Do Futher Filtering?\n1.Yes\n2.no");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    ApplyFloorFilter(filter);
                }
                else if (input == 2)
                {
                    List<SeatAllocationReportResponse> reports = report.SeatReport(filter);
                    ReportConsoleOutput.SeatReportConsoleOutput(reports.ToList());
                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }
        }

        public void ApplyFloorFilter(SeatAllocationReportRequest filter)
        {
            IEnumerable<Facility> floorlist = facility.GetData().Where(f => f.BuildingId == filter.BuildingId);

            foreach (Facility? f in floorlist)
            {
                Console.WriteLine($"floor: {f.Floor}   FacilityName:{f.FacilityName}");
            }
            Console.WriteLine("Enter Floor to filter:");
            int floorInput = Convert.ToInt32(Console.ReadLine());

            IEnumerable<Facility> floortofilter = floorlist.Where(b => b.Floor == floorInput);

            if (floortofilter == null)
            {
                Console.WriteLine("Enter Valid floor");
            }
            else
            {
                filter.FloorNumber = floorInput;
                /* Console.WriteLine("Do Futher Filtering?\n1.Yes\n2.no");
                 int input = Convert.ToInt32(Console.ReadLine());
                 if (input == 1)
                 {
                     applyfacilityFilter(floorInput);
                 }
                 else if (input == 2)
                 {*/
                List<SeatAllocationReportResponse> reports = report.SeatReport(filter);
                ReportConsoleOutput.SeatReportConsoleOutput(reports.ToList());
                /*
                                }
                                else
                                {
                                    Console.WriteLine("Enter Valid Input");
                                }*/
            }

        }

        public void ApplyCityFilter(SeatAllocationReportRequest filter)
        {
            List<City> cityList = city.GetData();


            foreach (City f in cityList)
            {
                Console.WriteLine($" CityId: {f.CityId} CityName:{f.CityName}");
            }
            Console.WriteLine("Enter City to filter:");
            string cityInput = Console.ReadLine();

            City? citytofilter = cityList.FirstOrDefault(b => b.CityName == cityInput);

            if (citytofilter == null)
            {
                Console.WriteLine("Enter Valid city");
            }

            else
            {
                filter.CityId = citytofilter.CityId;
                Console.WriteLine("Do Futher Filtering?\n1.Yes\n2.no");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    ApplyBuildingFilter(filter);
                }
                else if (input == 2)
                {
                    List<SeatAllocationReportResponse> reports = report.SeatReport(filter);
                    ReportConsoleOutput.SeatReportConsoleOutput(reports.ToList());
                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }

        }
    }
}
