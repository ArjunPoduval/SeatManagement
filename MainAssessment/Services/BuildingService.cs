﻿using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
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
            City exist = _cityRepository.GetById(cityId);

            //validation
            if (exist == null)
            {
                throw new ObjectDoNotExist("City");
            }

            Building? buildingcreation = _buildingRepository.GetAll().FirstOrDefault(c => c.BuildingName == building.BuildingName && c.BuildingAbbreviation == building.BuildingAbbreviation);
            if (buildingcreation != null)
            {
                throw new ObjectAlreadyExistException("Building");
            }
            //insertion   
            Building item = new()
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

            Building item = _buildingRepository.GetById(buildingId);
            if (item == null)
            {
                throw new ObjectDoNotExist("Building");
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
