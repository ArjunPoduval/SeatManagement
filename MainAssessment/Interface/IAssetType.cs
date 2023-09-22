﻿using MainAssessment.DTO;
using MainAssessment.Tables;
using System;
using System.Collections.Generic;

namespace MainAssessment.Interface
{
    public interface IAssetType
    {
        IEnumerable<AssetLookup> GetAllAssetTypes();
        void AddAssetType(AssetTypeCreation assetTypeCreation);
        void RemoveAssetType(int assetLookupId);
    }
}
