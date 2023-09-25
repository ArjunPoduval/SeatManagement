using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class AssetsService : IAsset
    {
        private readonly IRepository<Assets> _assetRepository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<MeetingRoom> _meetingRoomRepository;
        private readonly IRepository<AssetType> _assetTypeRepository;

        public AssetsService(IRepository<Assets> assetsRepository,
                             IRepository<Facility> facilityRepository,
                             IRepository<MeetingRoom> meetingRoomRepository,
                             IRepository<AssetType> assetlookupRepository)
        {
            _assetRepository = assetsRepository;
            _facilityRepository = facilityRepository;
            _meetingRoomRepository = meetingRoomRepository;
            _assetTypeRepository = assetlookupRepository;
        }

        public IEnumerable<Assets> GetAllAssets()
        {
            return _assetRepository.GetAll();
        }

        public void AddAssets(AssetCreationDTO assets)
        {
            //Validation
            // Check if FacilityId exists in Facility table
            if (!_facilityRepository.GetAll().Any(f => f.FacilityId == assets.FacilityId))
            {
                throw new Exception("The Facility does not exist.");
            }
            // Check if Assetid exists in Assetlookup table
            if (!_assetTypeRepository.GetAll().Any(a => a.AssetId == assets.AssetId))
            {
                throw new Exception("The Asset does not exist.");
            }

            //creation
            Assets item = new()
            {
                FacilityId = assets.FacilityId,
                AssetId = assets.AssetId
            };
            _assetRepository.Add(item);

            _assetRepository.Save();
        }

        public void UpdateAssetDetails(int IndexId, int? MeetingRoomId)
        {
            Assets assetDetails = _assetRepository.GetById(IndexId);
            if (assetDetails == null)
            {
                throw new Exception("The Assets record does not exist.");
            }

            //validation
            if (MeetingRoomId != null && assetDetails.MeetingRoomId != null)
            {
                throw new Exception("The Asset is already allocated");
            }

            if (MeetingRoomId == null && assetDetails.MeetingRoomId == null)
            {
                throw new Exception("The Asset is already unallocated");
            }

            // Check if MeetingRoomId exists in MeetingRoomTable in the same facility.
            if (MeetingRoomId.HasValue &&
                !_meetingRoomRepository.GetAll().Any(m => m.MeetingRoomId == MeetingRoomId &&
                m.FacilityId == assetDetails.FacilityId))
            {
                throw new Exception("The MeetingRoom does not exist in the given facility.");
            }

            // Update properties with new values

            assetDetails.MeetingRoomId = MeetingRoomId;

            _assetRepository.Update(assetDetails);
            _assetRepository.Save();
        }

        public void RemoveAssets(int assetsIndexId)
        {
            //validation
            Assets assets = _assetRepository.GetById(assetsIndexId);
            if (assets == null)
            {
                throw new ObjectDoNotExist();
            }

            //Remove
            else
            {
                _assetRepository.Remove(assets);
                _assetRepository.Save();
            }
        }
    }
}
