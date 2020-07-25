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
        public ObjectResponse<bool> Insert(List<RawMaterialProvider> rawMaterialProviders)
        {
            foreach (var rawMaterialProvider in rawMaterialProviders)
            {
                var response = Repository.Insert(rawMaterialProvider);
                if (!response.IsSuccess)
                    return response;
            }
            return new ObjectResponse<bool>(true, "Relacion creada exitosamente");
        }

        public ObjectResponse<bool> Update(List<RawMaterialProvider> rawMaterialProviders, int rawMaterialId)
        {
            var currentRawMaterialProviders = GetByRawMaterial(rawMaterialId);
            if (!currentRawMaterialProviders.IsSuccess)
                return new ObjectResponse<bool>(false, currentRawMaterialProviders.Message);

            var rawMaterialProvidersId = rawMaterialProviders.Select(x => x.RawMaterialProviderId).ToList();
            var editRawMaterialProviders = currentRawMaterialProviders.Data.Where(x => rawMaterialProvidersId.Contains(x.RawMaterialProviderId)).ToList();
            var addRawMaterialProviders = currentRawMaterialProviders.Data.Where(x => x.RawMaterialProviderId == 0).ToList();
            var deleteRawMaterialProviders = currentRawMaterialProviders.Data.Where(x => !rawMaterialProvidersId.Contains(x.RawMaterialProviderId)).ToList();

            RouteUpdateActions(editRawMaterialProviders,addRawMaterialProviders,deleteRawMaterialProviders);

            return new ObjectResponse<bool>(true, "Relacion actualizada exitosamente");
        }

        public ObjectResponse<bool> RouteUpdateActions(List<RawMaterialProvider> editRawMaterialProviders, List<RawMaterialProvider> addRawMaterialProviders, List<RawMaterialProvider> deleteRawMaterialProviders)
        {
            var insertResponse = Insert(addRawMaterialProviders);
            if (!insertResponse.IsSuccess)
                return insertResponse;

            var deleteResponse = Delete(deleteRawMaterialProviders.Select(x => x.RawMaterialProviderId).ToList());
            if (!deleteResponse.IsSuccess)
                return deleteResponse;

            foreach (var rawMaterialProvider in editRawMaterialProviders)
            {
                var editResponse = Repository.Update(rawMaterialProvider);
                if (!editResponse.IsSuccess)
                    return editResponse;
            }

            return new ObjectResponse<bool>(true, "Relacion editada exitosamente");

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
