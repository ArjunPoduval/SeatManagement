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

        public IEnumerable<AssetLookup> GetAllAssetLookups()
        {
            return _assetLookupRepository.GetAll();
        }

        public void AddAssetLookup(string AssetName)
        {
        //Validation
            var lookupcreation = _assetLookupRepository.GetAll().FirstOrDefault(c => c.AssetName==AssetName);
            if (lookupcreation != null)
            {
                throw new Exception("Similar Asset already exist.");
            }
        //Creation
            var item = new AssetLookup()
            {
                AssetName = AssetName
            };
            _assetLookupRepository.Add(item);
            _assetLookupRepository.Save();
        }

        public void UpdateAssetLookup(int assetLookupId, string AssetName)
        {
        //Validation
            var assetLookup = _assetLookupRepository.GetById(assetLookupId);
            if (assetLookup == null)
            {
                throw new Exception("The Asset does not exist.");
            }
            var Lookupcheck = _assetLookupRepository.GetAll().FirstOrDefault(c => c.AssetName == AssetName);
            if (Lookupcheck != null)
            {
                throw new Exception("Similar Asset already exist.");
            }

        // Update the AssetName
            assetLookup.AssetName = AssetName;

            _assetLookupRepository.Update(assetLookup);
            _assetLookupRepository.Save();
        }

        public void RemoveAssetLookup(int assetLookupId)
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
