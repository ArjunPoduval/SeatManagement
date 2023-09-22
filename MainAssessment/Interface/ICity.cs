using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface ICity
    {
        IEnumerable<City> GetAllCity();
        void AddCity(CityDTO City);
        void RemoveCity(int CityID);
    }
}
