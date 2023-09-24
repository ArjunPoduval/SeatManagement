using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.services
{
    public class FacilityService : IFacility
    {
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<Building> _buildingRepository;

        public FacilityService(IRepository<Facility> repository, IRepository<Building> buildingRepository)
        {
            this._facilityRepository = repository;
            this._buildingRepository = buildingRepository;
        }

        public IEnumerable<Facility> GetAll()
        {
            return _facilityRepository.GetAll();
        }

        public void AddFacility(FacilityDTO facility)
        {
        //Validation
            int buildingId = facility.BuildingId;
            var exist = _buildingRepository.GetById(buildingId);
            //building id validation
            if (exist == null)
            {
                throw new Exception("The Building Id does not exist.");
            }
            //facilityname validation
            var facilitycheck = _facilityRepository.GetAll().FirstOrDefault(c => c.FacilityName == facility.FacilityName && c.Floor == facility.Floor);
            if (facilitycheck != null)
            {
                throw new Exception("Facility with the same Name exist in the same floor");
            }
        //creation
            var item = new Facility()
            {
                BuildingId = facility.BuildingId,
                Floor = facility.Floor,
                FacilityName = facility.FacilityName
            };
            _facilityRepository.Add(item);
            _facilityRepository.Save();
        }

        public void RemoveFacility(int FacilityId)
        {
        //Validation
            var item = _facilityRepository.GetById(FacilityId);
            if (item == null)
            {
                throw new Exception("The Facility does not exist.");
            }
        //Removing
            else
            {
                _facilityRepository.Remove(item);
                _facilityRepository.Save();
            }
        }
    }
}
