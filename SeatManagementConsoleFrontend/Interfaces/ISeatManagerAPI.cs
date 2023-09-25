using MainAssessment.DTO;

namespace SeatManagementConsoleFrontend.Interfaces
{
    internal interface ISeatManagerAPI<T> where T : class
    {
        string CreateData(T data);
        List<T> GetData();
        string UpdateDetail(int IndexId, int? Id);
        string UpdateAssetDetail(int IndexId, int? Id);
        List<T> GenerateReport(SeatAllocationReportRequest requestFilter);
        void DeleteData(T data);
    }

}
