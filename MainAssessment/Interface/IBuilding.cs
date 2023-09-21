using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IBuilding
    {
        IEnumerable<Building> GetAll();
        void  AddBuilding(BuildingDTO building);
        void RemoveBuilding(int BuildingId);
    }
}
