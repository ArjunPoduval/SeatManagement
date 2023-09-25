using MainAssessment.DTO;
using MainAssessment.Tables;

namespace MainAssessment.Interface
{
    public interface IAsset
    {
        IEnumerable<Assets> GetAllAssets();
        void AddAssets(AssetCreationDTO assets);
        void UpdateAssetDetails(int indexId, int? MeetingRoomId);
        void RemoveAssets(int assetsIndexId);
    }
}
