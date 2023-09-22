using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainAssessment.services
{
    public class AssetTypeService : IAssetType
    {
        private readonly IRepository<AssetType> _assetLookupRepository;

        public AssetTypeService(IRepository<AssetType> assetLookupRepository)
        {
            _assetLookupRepository = assetLookupRepository;
        }

        public IEnumerable<AssetType> GetAllAssetTypes()
        {
            return _assetLookupRepository.GetAll();
        }

        public void AddAssetType(AssetTypeCreation newAssetType)
        {
        //Validation
            var lookupcreation = _assetLookupRepository.GetAll().FirstOrDefault(c => c.AssetName==newAssetType.assetName);
            if (lookupcreation != null)
            {
                throw new Exception("Similar Asset already exist.");
            }
        //Creation
            var item = new AssetType()
            {
                AssetName = newAssetType.assetName
            };
            _assetLookupRepository.Add(item);
            _assetLookupRepository.Save();
        }

        public void RemoveAssetType(int assetLookupId)
        {
        //Validation
            var assetLookup = _assetLookupRepository.GetById(assetLookupId);
            if (assetLookup == null)
            {
                throw new Exception("The Asset does not exist.");
            }
        //Removing
            else
            {
                _assetLookupRepository.Remove(assetLookup);
                _assetLookupRepository.Save();
            }
        }
    }
}
