using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IAsset
    {
        IEnumerable<Assets> GetAllAssets();
        void AddAssets(AssetInsertionDTO assets);
        void UpdateAssetDetails(int assetsIndexId, int? meetingRoomId);
        void RemoveAssets(int assetsIndexId);
    }
}
