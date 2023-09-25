using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IBuilding
    {
        IEnumerable<Building> GetAllBuildings();
        void AddBuilding(BuildingDTO building);
        void RemoveBuilding(int buildingId);
    }
}
