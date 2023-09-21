using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class BuildingService : IBuilding
    {
        private readonly IRepository<Building> repository;
        private readonly IRepository<CityLookup> Cityrepository;
        public BuildingService(IRepository<Building> repository, IRepository<CityLookup> repository1)
        {
            this.repository = repository;
            this.Cityrepository = repository1;
        }

        public IEnumerable<Building> GetAll()
        {
          
            return (repository.GetAll());
        }

        public void AddBuilding(BuildingDTO building)
        {
            int cityid = building.CityId;
            var exist = Cityrepository.GetById(cityid);

        //validation
            if (exist == null)
            {
                throw new Exception("The City Id does not exist.");
            }
            
            var buildingcreation = repository.GetAll().FirstOrDefault(c => c.BuildingName == building.BuildingName && c.BuildingAbbreviation == building.BuildingAbbreviation);
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
            repository.Add(item);
            repository.Save();
        }
        public void RemoveBuilding(int buildingId)
        {
        //validation

            var item = repository.GetById(buildingId);
            if (item == null)
            {
                throw new Exception("The Building does not exist.");
            }

        //removing
            else
            {
                repository.Remove(item);
                repository.Save();
            }
        }
  
    }
}
