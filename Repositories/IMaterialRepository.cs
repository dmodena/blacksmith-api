﻿using BlacksmithAPI.Models;

public interface IMaterialRepository
{
    public Material GetById(string id);
    public float GetMaterialPriceModifier(string materialId);
}
