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
        public static RawMaterialProvider FinishToInsert(RawMaterialProvider rawMaterialProvider)
        {
            rawMaterialProvider.DateCreate = DateTime.Now;
            rawMaterialProvider.DateUpdate = DateTime.Now;
            rawMaterialProvider.UserCreate = "";//pendiente de implementar
            rawMaterialProvider.UserUpdate = "";//pendiente de implementar

            return rawMaterialProvider;
        }

        public static RawMaterialProvider FinishToUpdate(RawMaterialProvider rawMaterialProvider)
        {
            rawMaterialProvider.DateUpdate = DateTime.Now;
            rawMaterialProvider.UserUpdate = "";//pendiente de implementar

            return rawMaterialProvider;
        }

        public static List<RawMaterialProviderDTO> FinishToGetAll(List<RawMaterialProviderDTO> rawMaterialProvidersDTO, List<RawMaterialDTO> rawMaterialsDTO, List<ProviderDTO> providersDTO, List<MeasureDTO> measuresDTO)
        {
            rawMaterialProvidersDTO.ForEach(x => x.RawMaterialDTO = rawMaterialsDTO.FirstOrDefault(y => y.RawMaterialId == x.RawMaterialId));
            rawMaterialProvidersDTO.ForEach(x => x.ProviderDTO = providersDTO.FirstOrDefault(y => y.ProviderId == x.ProviderId));
            rawMaterialProvidersDTO.ForEach(x => x.MeasureDTO = measuresDTO.FirstOrDefault(y => y.MeasureID == x.MeasureId));

            return rawMaterialProvidersDTO;
        }
    }
}
