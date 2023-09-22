using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MainAssessment.services
{
    public class AssetLookupService : IAssetType
    {
        private readonly IRepository<AssetLookup> _assetLookupRepository;

        public AssetLookupService(IRepository<AssetLookup> assetLookupRepository)
        {
            _assetLookupRepository = assetLookupRepository;
        }

        public IEnumerable<AssetLookup> GetAllAssetTypes()
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
            var item = new AssetLookup()
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
