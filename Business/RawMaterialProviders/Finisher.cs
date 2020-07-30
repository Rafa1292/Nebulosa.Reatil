using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.RawMaterialProviders
{
    public class Finisher
    {
        public static RawMaterialProvider FinishToDatabase(RawMaterialProvider rawMaterialProvider, int rawMaterialId)
        {
            if (!(rawMaterialProvider.DateCreate > new DateTime(1 / 1 / 1)))
            {
                rawMaterialProvider.DateCreate = DateTime.Now;
                rawMaterialProvider.UserCreate = "";//pendiente de implementar
            }

            rawMaterialProvider.RawMaterialId = rawMaterialId;
            rawMaterialProvider.DateUpdate = DateTime.Now;
            rawMaterialProvider.UserUpdate = "";//pendiente de implementar


            return rawMaterialProvider;
        }

        public static List<RawMaterialProviderDTO> FinishToGetAll(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, List<ProviderDTO> providersDTO, List<MeasureDTO> measuresDTO, List<RawMaterialProviderBrandDTO> rawMaterialProviderBrandsDTO)
        {
            rawMaterialProvidersDTO.ForEach(x => x.ProviderDTO = providersDTO.FirstOrDefault(y => y.ProviderId == x.ProviderId));
            rawMaterialProvidersDTO.ForEach(x => x.MeasureDTO = measuresDTO.FirstOrDefault(y => y.MeasureId == x.MeasureId));
            rawMaterialProvidersDTO.ForEach(x => x.RawMaterialProviderBrandDTO = rawMaterialProviderBrandsDTO.FirstOrDefault(y => y.RawMaterialProviderId == x.RawMaterialProviderId));


            return rawMaterialProvidersDTO;
        }
    }
}
