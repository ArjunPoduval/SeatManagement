using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class BuildingService : IBuilding
    {
        private readonly IRepository<Building> _buildingRepository;
        private readonly IRepository<City> _cityRepository;
        public BuildingService(IRepository<Building> buildingRepository, IRepository<City> cityRepository)
        {
            this._buildingRepository = buildingRepository;
            this._cityRepository = cityRepository;
        }

        public IEnumerable<Building> GetAllBuildings()
        {

            return (_buildingRepository.GetAll());
        }

        public void AddBuilding(BuildingDTO building)
        {
            int cityId = building.CityId;
            var exist = _cityRepository.GetById(cityId);

            //validation
            if (exist == null)
            {
                throw new Exception("The City Id does not exist.");
            }

            var buildingcreation = _buildingRepository.GetAll().FirstOrDefault(c => c.BuildingName == building.BuildingName && c.BuildingAbbreviation == building.BuildingAbbreviation);
            if (buildingcreation != null)
            {
                throw new ObjectAlreadyExistException();
            }
            //insertion   
            var item = new Building()
            {
                BuildingAbbreviation = building.BuildingAbbreviation,
                BuildingName = building.BuildingName,
                CityId = building.CityId
            };
            _buildingRepository.Add(item);
            _buildingRepository.Save();
        }
        public void RemoveBuilding(int buildingId)
        {
            //validation

            var item = _buildingRepository.GetById(buildingId);
            if (item == null)
            {
                throw new Exception("The Building does not exist.");
            }

            //removing
            else
            {
                _buildingRepository.Remove(item);
                _buildingRepository.Save();
            }
        }

    }
}
