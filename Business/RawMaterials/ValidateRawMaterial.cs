using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.RawMaterials
{
    public class ValidateRawMaterial
    {
        public static ObjectResponse<bool> ValidateToInsert(RawMaterial rawMaterial, List<RawMaterial> rawMaterials)
        {
            bool validateRawMaterialName = String.IsNullOrWhiteSpace(rawMaterial.Name);

            if (validateRawMaterialName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool NameExist = rawMaterials
                .Where(x => x.RawMaterialId != rawMaterial.RawMaterialId)
                .Select(x => x.Name.ToLower())
                .Contains(rawMaterial.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");

            bool validateProvider = rawMaterial.ProviderId > 0 ? true : false;

            if (!validateProvider)
                return new ObjectResponse<bool>(false, "El proveedor debe ser valido");

            return new ObjectResponse<bool>(true, "Insumo validado");
        }
    }
}
