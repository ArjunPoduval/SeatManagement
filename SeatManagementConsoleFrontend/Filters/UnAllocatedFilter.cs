using MainAssessment.DTO;
using MainAssessment.Tables;
using SeatManagementConsoleFrontend.Interfaces;
using SeatManagementConsoleFrontend.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend.Filters
{
    internal class UnAllocatedFilter
    {
        ISeatManagerAPI<Building> buildings = new SeatManagementAPICall<Building>("Building");
        ISeatManagerAPI<Facility> Facility = new SeatManagementAPICall<Facility>("Facilities");
        Report report = new Report();
        ReportConsoleOutput output = new ReportConsoleOutput();

        public void applybuildingfilter()
        {
            var buildinglist = buildings.GetData();

            Console.WriteLine("Enter Building Id to filter:");
            foreach (var b in buildinglist)
            {
                Console.WriteLine($"BuildingId: {b.BuildingId}   BuildingName:{b.BuildingName}");
            }
            int buildInput = Convert.ToInt32(Console.ReadLine());

            var buildingtofilter = buildinglist.First(b => b.BuildingId == buildInput);

            if (buildingtofilter == null)
            {
                Console.WriteLine("Enter Valid BuildingId");
            }
            else
            {
                Console.WriteLine("Do Futher Filtering?\n1.Yes\n2.no");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    applyFloorFilter(buildInput);
                }
                else if (input == 2)
                {/*
                    var reports = report.unAllocatedreport().Where(r => r.BuildingAbbreviation == buildingtofilter.BuildingAbbreviation);
                    output.UnAllocatedReportConsoleOutput(reports.ToList());*/

                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }
        }
        public void applyFloorFilter(int Buildingid)
        {
            var floorlist = Facility.GetData().Where(f => f.BuildingId == Buildingid);

            Console.WriteLine("Enter Floor to filter:");
            foreach (var f in floorlist)
            {
                Console.WriteLine($"floor: {f.Floor}   FacilityName:{f.FacilityName}");
            }
            int floorInput = Convert.ToInt32(Console.ReadLine());

            var floortofilter = floorlist.Where(b => b.Floor == floorInput);

            if (floortofilter == null)
            {
                Console.WriteLine("Enter Valid floor");
            }
            else
            {
                Console.WriteLine("Do Futher Filtering?\n1.Yes\n2.no");
                int input = Convert.ToInt32(Console.ReadLine());
                if (input == 1)
                {
                    applyfacilityFilter(floorInput);
                }
                else if (input == 2)
                {
                  /*  var reports = report.unAllocatedreport().Where(r => r.Floor == floorInput);
                    output.UnAllocatedReportConsoleOutput(reports.ToList());*/

                }
                else
                {
                    Console.WriteLine("Enter Valid Input");
                }
            }

        }

        public void applyfacilityFilter(int floorInput)
        {
            var facilitylist = Facility.GetData().Where(f => f.Floor == floorInput);

            Console.WriteLine("Enter facility to filter:");
            foreach (var f in facilitylist)
            {
                Console.WriteLine($" FacilityName:{f.FacilityName}");
            }
            string facilityInput = Console.ReadLine();

            var facilitytofilter = facilitylist.Where(b => b.FacilityName == facilityInput);

            if (facilitytofilter == null)
            {
                Console.WriteLine("Enter Valid facility");
            }

            else
            {
                //Console.WriteLine("Do Futher Filtering?\n1.Yes\n2.no");
                //int input = Convert.ToInt32(Console.ReadLine());
                //if (input == 1)
                //{
                //    applyfacilityFilter(floorInput);
                //}
                //else if (input == 2)
                //{
               /* var reports = report.unAllocatedreport().Where(r => r.FacilityName == facilityInput);
                output.UnAllocatedReportConsoleOutput(reports.ToList());*/
                //}
                //else
                //{
                //    Console.WriteLine("Enter Valid Input");
                //}
            }

        }
    }
}
