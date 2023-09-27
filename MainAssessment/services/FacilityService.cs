using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

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
            Building exist = _buildingRepository.GetById(buildingId);
            //building id validation
            if (exist == null)
            {
                throw new ObjectDoNotExist("Building");
            }
            //facilityname validation
            Facility? facilitycheck = _facilityRepository.GetAll().FirstOrDefault(c => c.FacilityName == facility.FacilityName && c.Floor == facility.Floor);
            if (facilitycheck != null)
            {
                throw new ObjectAlreadyExistException("Facility in same floor");
            }
            //creation
            Facility item = new()
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
            Facility item = _facilityRepository.GetById(FacilityId);
            if (item == null)
            {
                throw new ObjectDoNotExist("Facility");
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
