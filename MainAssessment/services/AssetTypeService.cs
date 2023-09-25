using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

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
            AssetType? newTypecreation = _assetTypeRepository.GetAll().FirstOrDefault(c => c.AssetName == newAssetType.assetName);
            if (newTypecreation != null)
            {
                throw new ObjectAlreadyExistException();
            }
            //Creation
            AssetType item = new()
            {
                AssetName = newAssetType.assetName
            };
            _assetTypeRepository.Add(item);
            _assetTypeRepository.Save();
        }

        public void RemoveAssetType(int assetTypeId)
        {
            //Validation
            AssetType assetType = _assetTypeRepository.GetById(assetTypeId);
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
