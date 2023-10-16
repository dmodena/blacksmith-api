﻿using BlacksmithAPI.Data;
using BlacksmithAPI.Models;

internal class InventoryRepository
{
    public Material GetById(string id)
    {
        return BlacksmithDatabase.Get<Material>("materials", x => x.Id == id);
    }

    public float GetMaterialPriceModifier(string materialId)
    {
        var material = GetById(materialId);

        return material.PriceModifier;
    }
}