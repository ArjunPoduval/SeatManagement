using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class BuildingService : IBuilding
    {
        private readonly IRepository<Building> buildingRepository;
        private readonly IRepository<CityLookup> cityRepository;
        public BuildingService(IRepository<Building> buildingRepository, IRepository<CityLookup> cityRepository)
        {
            this.buildingRepository = buildingRepository;
            this.cityRepository = cityRepository;
        }

        public IEnumerable<Building> GetAllBuildings()
        {

            return (buildingRepository.GetAll());
        }

        public void AddBuilding(BuildingDTO building)
        {
            int cityId = building.CityId;
            var exist = cityRepository.GetById(cityId);

            //validation
            if (exist == null)
            {
                throw new Exception("The City Id does not exist.");
            }

            var buildingcreation = buildingRepository.GetAll().FirstOrDefault(c => c.BuildingName == building.BuildingName && c.BuildingAbbreviation == building.BuildingAbbreviation);
            if (buildingcreation != null)
            {
                throw new Exception("Similar Building Name or Abbreviation already exist.");
            }
            //insertion   
            var item = new Building()
            {
                BuildingAbbreviation = building.BuildingAbbreviation,
                BuildingName = building.BuildingName,
                CityId = building.CityId
            };
            buildingRepository.Add(item);
            buildingRepository.Save();
        }
        public void RemoveBuilding(int buildingId)
        {
            //validation

            var item = buildingRepository.GetById(buildingId);
            if (item == null)
            {
                throw new Exception("The Building does not exist.");
            }

            //removing
            else
            {
                buildingRepository.Remove(item);
                buildingRepository.Save();
            }
        }

    }
}
