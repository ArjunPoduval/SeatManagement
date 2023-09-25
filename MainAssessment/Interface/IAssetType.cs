using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IAssetType
    {
        IEnumerable<AssetType> GetAllAssetTypes();
        void AddAssetType(AssetTypeCreation assetTypeCreation);
        void RemoveAssetType(int assetLookupId);
    }
}
