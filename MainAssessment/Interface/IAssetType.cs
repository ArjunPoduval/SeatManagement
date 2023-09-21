using MainAssessment.DTO;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface IAssetType
    {
        IEnumerable<AssetLookup> GetAllAssetLookups();
        void AddAssetLookup(string AssetName);
        void UpdateAssetLookup(int assetLookupId,string AssetName);
        void RemoveAssetLookup(int assetLookupId);
    }
}
