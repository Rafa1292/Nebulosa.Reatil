using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.RawMaterials
{
    public class Finisher
    {
        public static RawMaterial FinishToDatabase(RawMaterial rawMaterial)
        {
            if (!(rawMaterial.DateCreate > new DateTime(1 / 1 / 1)))
            {
                rawMaterial.DateCreate = DateTime.Now;
                rawMaterial.UserCreate = "";//pendiente de implementar
            }
            rawMaterial.DateUpdate = DateTime.Now;
            rawMaterial.UserUpdate = "";//pendiente de implementar

            return rawMaterial;
        }


        public static RawMaterialDTO FinishToGet(RawMaterialDTO rawMaterialDTO, List<RawMaterialProviderDTO> rawMaterialprovidersDTO)
        {
            var rawMaterialProviderDTO = rawMaterialprovidersDTO.Find(x => x.RawMaterialId == rawMaterialDTO.RawMaterialId && x.ProviderId == rawMaterialDTO.ProviderId);
            rawMaterialDTO.rawMaterialProvidersDTO = rawMaterialprovidersDTO.Where(x => x.RawMaterialId == rawMaterialDTO.RawMaterialId).ToList();
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
