using Business.RawMaterialProviders;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RawMaterialProviders
{
    public class ImplementerRawMaterialProvider : IRawMaterialProvider
    {
        public ObjectResponse<int> Insert(RawMaterialProvider rawMaterialProvider)
        {
            var response = Repository.Insert(rawMaterialProvider);
            if (!response.IsSuccess)
                return response;

            return new ObjectResponse<int>(true, "Relacion creada exitosamente", response.Data);
        }

        public ObjectResponse<bool> Update(RawMaterialProvider rawMaterialProvider)
        {
            var response = Repository.Update(rawMaterialProvider);
            if (!response.IsSuccess)
                return response;

            return new ObjectResponse<bool>(true, "Relacion actualizada exitosamente");
        }

        public ObjectResponse<bool> Delete(List<int> rawMaterialProvidersId)
        {
            foreach (var rawMaterialProviderId in rawMaterialProvidersId)
            {
                var response = Repository.Delete(rawMaterialProviderId);
                if (!response.IsSuccess)
                    return response;
            }
            return new ObjectResponse<bool>(true, "Relacion eliminada exitosamente");
        }

        public ObjectResponse<List<RawMaterialProvider>> GetByRawMaterial(int rawMaterialId)
        {
            var rawMaterialProviders = Repository.GetAll();
            if (!rawMaterialProviders.IsSuccess)
                return rawMaterialProviders;

            rawMaterialProviders.Data = rawMaterialProviders.Data.Where(x => x.RawMaterialId == rawMaterialId).ToList();
            return rawMaterialProviders;
        }

        public ObjectResponse<List<RawMaterialProvider>> GetByProvider(int providerId)
        {
            var rawMaterialProviders = Repository.GetAll();
            if (!rawMaterialProviders.IsSuccess)
                return rawMaterialProviders;

            rawMaterialProviders.Data = rawMaterialProviders.Data.Where(x => x.ProviderId == providerId).ToList();
            return rawMaterialProviders;
        }


        public ObjectResponse<List<RawMaterialProvider>> GetAll(bool deleteItems)
        {
            var rawMaterials = Repository.GetAll();

            if (!rawMaterials.IsSuccess)
                return rawMaterials;

            if (!deleteItems)
                rawMaterials.Data = rawMaterials.Data.Where(x => !x.Delete).ToList();

            return rawMaterials;
        }
    }
}
