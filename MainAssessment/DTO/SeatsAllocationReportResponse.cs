namespace MainAssessment.Tables
{
    public class SeatAllocationReportResponse
    {
        public int SeatId { get; set; }
        public string CityAbbreviation { get; set; }
        public string BuildingAbbreviation { get; set; }
        public int Floor { get; set; }
        public string FacilityName { get; set; }
        public int SeatNumber { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}
