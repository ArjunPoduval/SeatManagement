using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class SeatReportService : IReportCall
    {

        private readonly IRepository<AllocatedSeatsReport> _allocatedSeatReportRepository;
        private readonly IRepository<UnAllocatedSeatsReport> _unallocatedSeatReportRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Building> _buildingRepository;

        public SeatReportService(IRepository<AllocatedSeatsReport> allocatedSeats,
                IRepository<City> cityRepo,
                IRepository<Building> buildingRepository,
                IRepository<UnAllocatedSeatsReport> unallocatedSeats)
        {
            _allocatedSeatReportRepository = allocatedSeats;
            _unallocatedSeatReportRepository = unallocatedSeats;
            _cityRepository = cityRepo;
            _buildingRepository = buildingRepository;
        }

        public IEnumerable<SeatAllocationReportResponse> GenerateSeatAllocationReport(SeatAllocationReportRequest reportFilter)
        {
            if (reportFilter.AllocationType == 1)
            {
                return GetAllAllocatedSeats(reportFilter);
            }
            else if (reportFilter.AllocationType == 2)
            {
                return GetAllUnallocatedSeats(reportFilter);
            }

            throw new NotImplementedException();
        }

        private IEnumerable<SeatAllocationReportResponse> GetAllAllocatedSeats(SeatAllocationReportRequest reportFilter)
        {
            var allocatedReportResponse = _allocatedSeatReportRepository.GetAll();
            var reportResponse = MapAllocatedReportToSeatAllocationResponse(allocatedReportResponse);
            reportResponse = FilterSeatAllocationReport(reportFilter, reportResponse);

            return reportResponse;
        }
        private IEnumerable<SeatAllocationReportResponse> GetAllUnallocatedSeats(SeatAllocationReportRequest reportFilter)
        {
            var unAllocatedReportResponse = _unallocatedSeatReportRepository.GetAll();
            var reportResponse = MapUnAllocatedReportToSeatAllocationResponse(unAllocatedReportResponse);
            reportResponse = FilterSeatAllocationReport(reportFilter, reportResponse);

            return reportResponse;
        }

        private IEnumerable<SeatAllocationReportResponse>? FilterSeatAllocationReport(SeatAllocationReportRequest reportFilter, IEnumerable<SeatAllocationReportResponse>? reportResponse)
        {
            if (reportFilter.CityId != 0)
            {
                var cityFiltered = _cityRepository.GetById(reportFilter.CityId) ?? throw new ObjectDoNotExist();
                reportResponse = reportResponse.Where(c => c.CityAbbreviation == cityFiltered.CityAbbreviation);

                if (reportFilter.BuildingId != 0)
                {
                    var buildingFiltered = _buildingRepository.GetById(reportFilter.BuildingId) ?? throw new ObjectDoNotExist();
                    reportResponse = reportResponse.Where(c => c.BuildingAbbreviation == buildingFiltered.BuildingAbbreviation);

                    if (reportFilter.FloorNumber != 0)
                    {
                        reportResponse = reportResponse.Where(c => c.Floor == reportFilter.FloorNumber);
                    }
                }
            }

            return reportResponse;
        }


        private static IEnumerable<SeatAllocationReportResponse> MapAllocatedReportToSeatAllocationResponse(IEnumerable<AllocatedSeatsReport> response)
        {
            return response.Select((report) => new SeatAllocationReportResponse
            {
                BuildingAbbreviation = report.BuildingAbbreviation,
                CityAbbreviation = report.CityAbbreviation,
                EmployeeId = report.EmployeeId,
                EmployeeName = report.EmployeeName,
                FacilityName = report.FacilityName,
                Floor = report.Floor,
                SeatId = report.SeatId,
                SeatNumber = report.SeatNumber,
            });
        } 
        
        private static IEnumerable<SeatAllocationReportResponse> MapUnAllocatedReportToSeatAllocationResponse(IEnumerable<UnAllocatedSeatsReport> response)
        {
            return response.Select((report) => new SeatAllocationReportResponse
            {
                BuildingAbbreviation = report.BuildingAbbreviation,
                CityAbbreviation = report.CityAbbreviation,
                FacilityName = report.FacilityName,
                Floor = report.Floor,
                SeatId = report.SeatId,
                SeatNumber = report.SeatNumber,
            });
        }
    }

}
