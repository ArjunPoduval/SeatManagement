using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainAssessment.services
{
    public class AssetsService : IAsset
    {
        private readonly IRepository<Assets> _assetsRepository;
        private readonly IRepository<Facility> _facilityRepository;
        private readonly IRepository<MeetingRoomTable> _meetingRoomRepository;
        private readonly IRepository<AssetType> _assetlookupRepository;

        public AssetsService(IRepository<Assets> assetsRepository,
                             IRepository<Facility> facilityRepository,
                             IRepository<MeetingRoomTable> meetingRoomRepository,
                             IRepository<AssetType> assetlookupRepository)
        {
            _assetsRepository = assetsRepository;
            _facilityRepository = facilityRepository;
            _meetingRoomRepository = meetingRoomRepository;
            _assetlookupRepository = assetlookupRepository;
        }

        public IEnumerable<Assets> GetAllAssets()
        {
            return _assetsRepository.GetAll();
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
            if (!_assetlookupRepository.GetAll().Any(a => a.AssetId == assets.AssetId))
            {
                throw new Exception("The Asset does not exist.");
            }

            //creation
            var item = new Assets()
            {
                FacilityId = assets.FacilityId,
                AssetId = assets.AssetId
            };
            _assetsRepository.Add(item);

            _assetsRepository.Save();
        }

        public void UpdateAssetDetails(int assetsIndexId, int? MeetingRoomId)
        {
            var assetDetails = _assetsRepository.GetById(assetsIndexId);
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

            _assetsRepository.Update(assetDetails);
            _assetsRepository.Save();
        }

        public void RemoveAssets(int assetsIndexId)
        {
            //validation
            var assets = _assetsRepository.GetById(assetsIndexId);
            if (assets == null)
            {
                throw new Exception("The Assets record does not exist.");
            }

            //Remove
            else
            {
                _assetsRepository.Remove(assets);
                _assetsRepository.Save();
            }
        }
    }
}
