

using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.services;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Builder;
using MySqlX.XDevAPI;
using SeatManagementConsoleFrontend;
using SeatManagementConsoleFrontend.Filters;
using SeatManagementConsoleFrontend.Interfaces;
using SeatManagementConsoleFrontend.Reports;
using System.Composition;

class Program
{
    public static void Main(string[] args)
    {
        Onboarding onboarding = new Onboarding();
        Allocate allocation = new Allocate();
        Deallocate Deallocation = new Deallocate();
        Report reporting = new Report();
        AllocatedFilter Allocatedfiltering = new AllocatedFilter();
        UnAllocatedFilter unallocatedfiltering = new UnAllocatedFilter();
        ReportConsoleOutput output = new ReportConsoleOutput();

        Console.WriteLine("Welcome to the Seat Management System!");
        while (true)
        {
            Console.WriteLine("\n<--- Main Menu --->");
            Console.WriteLine("1. Onboard Employee");
            Console.WriteLine("2. Onboard a Facility");
            Console.WriteLine("3. Onboard Seats"); 
            Console.WriteLine("4. Onboard Cabins");
            Console.WriteLine("5. Onboard Meeting Rooms");
            Console.WriteLine("6. Onboard Assets");
            Console.WriteLine("7. Allocate Asset to Meeting Room");
            Console.WriteLine("8. DeAllocate Asset from Meeting Room");
            Console.WriteLine("9. Allocate Employee");
            Console.WriteLine("10. DeAllocate Employee");
            Console.WriteLine("11. Generate Reports");
            Console.WriteLine("12. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    onboarding.OnboardEmployee();
                    break;

                case "2":
                    onboarding.OnboardFacility();
                    break;

                case "3":
                    onboarding.OnboardSeats();
                    break;

                case "4":
                    onboarding.OnboardCabin();
                    break;

                case "5":
                    onboarding.OnboardMeetingroom(); 
                    break;

                case "6":
                    onboarding.OnboardAssets(); 
                    break;

                case "7":
                    allocation.AllocateAssettoMeetingroom();
                    break;

                case "8":
                    Deallocation.DeAllocateAssetFromMeetingroom();
                    break;

                case "9":
                    Console.WriteLine("1.Allocate to Seat\n2.Allocate to cabin\n");
                    int allocationInput = Convert.ToInt32(Console.ReadLine());
                    
                    if(allocationInput == 1)
                    {
                        allocation.AllocateEmployeeToSeat();
                        
                    }
                    else if(allocationInput == 2)
                    {
                        allocation.AllocateEmployeeToCabin();
                        
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Input.");
                        
                    }
                    break;
                
                case "10":
                    Console.WriteLine("1.DeAllocate from Seat\n2.DeAllocate from cabin\n");
                    int deallocationInput = Convert.ToInt32(Console.ReadLine());
                    
                    if(deallocationInput == 1)
                    {
                        Deallocation.DeAllocateEmployeeinSeat();
                        
                    }
                    else if(deallocationInput == 2)
                    {
                        Deallocation.DeAllocateEmployeeinCabin();
                        
                    }
                    else
                    {
                        Console.WriteLine("Enter Valid Input.");
                        
                    }
                    break;

                case "11":
                    Console.WriteLine("Generate Report For \n1.AllocatedSeat\n2.UnAllocatedSeat\n");
                    int input = Convert.ToInt32( Console.ReadLine());
                    

                    if (input == 1)
                    {
                        Console.WriteLine("Do you want to Apply any Filter: \n1.Yes\n2.No");
                        int filterinput = Convert.ToInt32(Console.ReadLine());

                        if(filterinput == 1)
                        {
                            Allocatedfiltering.applybuildingfilter();
                        }
                        else
                        {
                            var reports = reporting.Allocatedreport();
                            output.AllocatedReportConsoleOutput(reports.ToList());
                        }
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("Do you want to Apply any Filter: \n1.Yes\n2.No");
                        int filterinput = Convert.ToInt32(Console.ReadLine());

                        if (filterinput == 1)
                        {
                            unallocatedfiltering.applybuildingfilter();
                        }
                        else
                        {
                            /*var reports = reporting.unAllocatedreport();
                            output.UnAllocatedReportConsoleOutput(reports.ToList());*/

                        }


                    }
                    else
                    {
                        Console.WriteLine("Enter Valid input");
                    }

                    break;

                case "12":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }


}
