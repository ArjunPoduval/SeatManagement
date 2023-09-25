

using MainAssessment.DTO;
using SeatManagementConsoleFrontend;
using SeatManagementConsoleFrontend.Filters;
using SeatManagementConsoleFrontend.Reports;

internal class Program
{
    public static void Main(string[] args)
    {
        Onboarding onboarding = new();
        Allocate allocation = new();
        Deallocate Deallocation = new();
        Report reporting = new();
        SeatReportFiltering filtering = new();
        ReportConsoleOutput output = new();

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
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Onboarding.OnboardEmployee();
                    break;
                case 2:
                    Onboarding.OnboardFacility();
                    break;
                case 3:
                    Onboarding.OnboardSeats();
                    break;
                case 4:
                    Onboarding.OnboardCabin();
                    break;
                case 5:
                    Onboarding.OnboardMeetingroom();
                    break;
                case 6:
                    Onboarding.OnboardAssets();
                    break;
                case 7:
                    Allocate.AllocateAssetToMeetingRoom();
                    break;
                case 8:
                    Deallocation.DeAllocateAssetFromMeetingroom();
                    break;
                case 9:
                    Console.WriteLine("1.Allocate to Seat\n2.Allocate to cabin\n");
                    AllocateEmployee(allocation);
                    break;
                case 10:
                    Console.WriteLine("1.DeAllocate from Seat\n2.DeAllocate from cabin\n");
                    DeallocateEmployee(Deallocation);
                    break;
                case 11:
                    GenerateSeatReport(reporting, filtering, output);
                    break;
                case 12:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    private static void GenerateSeatReport(Report reporting, SeatReportFiltering filtering, ReportConsoleOutput output)
    {
        Console.WriteLine("Generate Report For \n1.AllocatedSeat\n2.UnAllocatedSeat\n");
        int input = Convert.ToInt32(Console.ReadLine());
        if (input == 1 || input == 2)
        {
            Console.WriteLine("Do you want to Apply any Filter: \n1.Yes\n2.No");
            int filterinput = Convert.ToInt32(Console.ReadLine());
            SeatAllocationReportRequest filter = new()
            {
                AllocationType = input,
            };
            if (filterinput == 1)
            {
                filtering.ApplyCityFilter(filter);
            }
            else
            {
                List<MainAssessment.Tables.SeatAllocationReportResponse> reports = reporting.SeatReport(filter);
                ReportConsoleOutput.SeatReportConsoleOutput(reports);
            }
        }
        else
        {
            Console.WriteLine("Enter Valid input");
        }
    }

    private static void DeallocateEmployee(Deallocate Deallocation)
    {
        int deallocationInput = Convert.ToInt32(Console.ReadLine());

        if (deallocationInput == 1)
        {
            Deallocation.DeAllocateEmployeeinSeat();
        }
        else if (deallocationInput == 2)
        {
            Deallocation.DeAllocateEmployeeinCabin();
        }
        else
        {
            Console.WriteLine("Enter Valid Input.");
        }
    }

    private static void AllocateEmployee(Allocate allocation)
    {
        int allocationInput = Convert.ToInt32(Console.ReadLine());

        if (allocationInput == 1)
        {
            Allocate.AllocateEmployeeToSeat();
        }
        else if (allocationInput == 2)
        {
            Allocate.AllocateEmployeeToCabin();
        }
        else
        {
            Console.WriteLine("Enter Valid Input.");
        }
    }
}
