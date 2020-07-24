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
        public static List<RawMaterialProvider> FinishToInsert(List<RawMaterialProvider> rawMaterialProviders, int rawMaterialId)
        {
            foreach (var rawMaterialProvider in rawMaterialProviders)
            {
                rawMaterialProvider.RawMaterialId = rawMaterialId;
                rawMaterialProvider.DateCreate = DateTime.Now;
                rawMaterialProvider.DateUpdate = DateTime.Now;
                rawMaterialProvider.UserCreate = "";//pendiente de implementar
                rawMaterialProvider.UserUpdate = "";//pendiente de implementar
            }


            return rawMaterialProviders;

        }

        public static List<RawMaterialProvider> FinishToUpdate(List<RawMaterialProvider> rawMaterialProviders)
        {
            foreach (var rawMaterialProvider in rawMaterialProviders)
            {
                rawMaterialProvider.DateUpdate = DateTime.Now;
                rawMaterialProvider.UserUpdate = "";//pendiente de implementar
            }
            return rawMaterialProviders;
        }

        public static List<RawMaterialProviderDTO> FinishToGetAll(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, List<ProviderDTO> providersDTO, List<MeasureDTO> measuresDTO)
        {
            rawMaterialProvidersDTO.ForEach(x => x.ProviderDTO = providersDTO.FirstOrDefault(y => y.ProviderId == x.ProviderId));
            rawMaterialProvidersDTO.ForEach(x => x.MeasureDTO = measuresDTO.FirstOrDefault(y => y.MeasureId == x.MeasureId));

            return rawMaterialProvidersDTO;
        }
    }
}
