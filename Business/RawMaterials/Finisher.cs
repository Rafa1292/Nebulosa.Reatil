using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterials
{
    public class Finisher
    {
        public static RawMaterial FinishToInsert(RawMaterial rawMaterial)
        {
            rawMaterial.DateCreate = DateTime.Now;
            rawMaterial.DateUpdate = DateTime.Now;
            rawMaterial.UserCreate = "";//pendiente de implementar
            rawMaterial.UserUpdate = "";//pendiente de implementar

            return rawMaterial;
        }

        public static RawMaterial FinishToUpdate(RawMaterial rawMaterial)
        {
            rawMaterial.DateUpdate = DateTime.Now;
            rawMaterial.UserUpdate = "";//pendiente de implementar

            return rawMaterial;
        }

        public static RawMaterialDTO FinishToGet(RawMaterialDTO rawMaterialDTO, List<RawMaterialProviderDTO> rawMaterialprovidersDTO)
        {
            var rawMaterialProviderDTO = rawMaterialprovidersDTO.Find(x => x.RawMaterialId == rawMaterialDTO.RawMaterialId && x.ProviderId == rawMaterialDTO.ProviderId);
            if (rawMaterialProviderDTO != null)
            {
                rawMaterialDTO.CurreentQuantity = rawMaterialProviderDTO.Quantity;
                rawMaterialDTO.CurrentPrice = rawMaterialProviderDTO.Price;
                rawMaterialDTO.CurrentWeight = rawMaterialProviderDTO.Weight;
            }


            return rawMaterialDTO;
        }

        public static List<RawMaterialDTO> FinishToGetAll(List<RawMaterialDTO> rawMaterialsDTO, List<RawMaterialProviderDTO> rawMaterialprovidersDTO)
        {
            rawMaterialsDTO.ForEach(x => x = FinishToGet(x, rawMaterialprovidersDTO));

            return rawMaterialsDTO;
        }

    }
}
