using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface ICity
    {
        IEnumerable<CityLookup> GetAllCity();
        void AddCity(CityLookupDTO City);
        void RemoveCity(int CityID);
        void UpdateCity(string cityName, CityLookupDTO updatedCityData);
    }
}
