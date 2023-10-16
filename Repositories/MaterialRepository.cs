using BlacksmithAPI.Data;
using BlacksmithAPI.Models;namespace BlacksmithAPI.Repositories;

internal class MaterialRepository : IMaterialRepository
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
