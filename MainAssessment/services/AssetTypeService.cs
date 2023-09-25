using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using NuGet.Protocol.Core.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using MainAssessment.CustomException;
using MainAssessment.Exceptions;

namespace MainAssessment.services
{
    public class AssetTypeService : IAssetType
    {
        private readonly IRepository<AssetType> _assetTypeRepository;

        public AssetTypeService(IRepository<AssetType> assetLookupRepository)
        {
            _assetTypeRepository = assetLookupRepository;
        }

        public IEnumerable<AssetType> GetAllAssetTypes()
        {
            return _assetTypeRepository.GetAll();
        }

        public void AddAssetType(AssetTypeCreation newAssetType)
        {
        //Validation
            var newTypecreation = _assetTypeRepository.GetAll().FirstOrDefault(c => c.AssetName==newAssetType.assetName);
            if (newTypecreation != null)
            {
                throw new ObjectAlreadyExistException();
            }
        //Creation
            var item = new AssetType()
            {
                AssetName = newAssetType.assetName
            };
            _assetTypeRepository.Add(item);
            _assetTypeRepository.Save();
        }

        public void RemoveAssetType(int assetTypeId)
        {
        //Validation
            var assetType = _assetTypeRepository.GetById(assetTypeId);
            if (assetType == null)
            {
                throw new ObjectDoNotExist();
            }
        //Removing
            else
            {
                _assetTypeRepository.Remove(assetType);
                _assetTypeRepository.Save();
            }
        }
    }
}
