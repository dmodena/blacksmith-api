using BlacksmithAPI.Models;namespace BlacksmithAPI.Repositories;

public interface IMaterialRepository
{
    public Material GetById(string id);
    public float GetMaterialPriceModifier(string materialId);
}

