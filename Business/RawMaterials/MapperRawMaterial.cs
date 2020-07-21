using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterials
{
    public class MapperRawMaterial
    {
        public static RawMaterial MapFromDTO(RawMaterialDTO rawMaterialDTO, RawMaterial rawMaterial)
        {
            rawMaterial.RawMaterialId = rawMaterialDTO.RawMaterialId;
            rawMaterial.Name = rawMaterialDTO.Name;
            rawMaterial.Stock = rawMaterialDTO.Stock;
            rawMaterial.LastPurchase = rawMaterialDTO.LastPurchase;
            rawMaterial.ProviderId = rawMaterialDTO.ProviderId;


            return rawMaterial;
        }

        public static RawMaterialDTO MapToDTO(RawMaterial rawMaterial)
        {
            RawMaterialDTO rawMaterialDTO = new RawMaterialDTO()
            {
                LastPurchase = rawMaterial.LastPurchase,
                Name = rawMaterial.Name,
                RawMaterialId = rawMaterial.RawMaterialId,
                ProviderId = rawMaterial.ProviderId,
                Stock = rawMaterial.Stock
            };

            return rawMaterialDTO;
        }

        public static List<RawMaterialDTO> MapToDTO(List<RawMaterial> rawMaterials)
        {
            List<RawMaterialDTO> rawMaterialsDTO = new List<RawMaterialDTO>();

            rawMaterials.ForEach(x => rawMaterialsDTO.Add(
                new RawMaterialDTO()
                {
                    LastPurchase = x.LastPurchase,
                    Name = x.Name,
                    RawMaterialId = x.RawMaterialId,
                    ProviderId = x.ProviderId,
                    Stock = x.Stock
                }));

            return rawMaterialsDTO;
        }
    }
}
