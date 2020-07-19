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
        public ObjectResponse<bool> Insert(RawMaterialProvider rawMaterialProvider)
        {
            return Repository.Insert(rawMaterialProvider);
        }

        public ObjectResponse<bool> Update(RawMaterialProvider rawMaterialProvider)
        {
            return Repository.Update(rawMaterialProvider);
        }

        public ObjectResponse<bool> Delete(int rawMaterialProviderId)
        {
            return Repository.Delete(rawMaterialProviderId);
        }

        public ObjectResponse<List<RawMaterialProvider>> GetByRawMaterial(int rawMaterialId)
        {
            var rawMaterialProviders = Repository.GetAll();
            if(!rawMaterialProviders.IsSuccess)
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
