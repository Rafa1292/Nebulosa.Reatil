using Business.RawMaterialProviderBrands;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RawMaterialProviderBrands
{
    public class ImplementerRawMaterialProviderBrand : IRawMaterialProviderBrand
    {
        public ObjectResponse<bool> Insert(List<RawMaterialProviderBrand> rawMaterialProviderBrands)
        {
            foreach (var rawMaterialProviderBrand in rawMaterialProviderBrands)
            {
                var response = Repository.Insert(rawMaterialProviderBrand);
                if (!response.IsSuccess)
                    return response;
            }
            return new ObjectResponse<bool>(true, "Relacion creada exitosamente");
        }

        public ObjectResponse<bool> RouteUpdateActions(List<RawMaterialProviderBrand> editRawMaterialProviderBrands, List<RawMaterialProviderBrand> addRawMaterialProviderBrands, List<RawMaterialProviderBrand> deleteRawMaterialProviderBrands)
        {
            var insertResponse = Insert(addRawMaterialProviderBrands);
            if (!insertResponse.IsSuccess)
                return insertResponse;

            var deleteResponse = Delete(deleteRawMaterialProviderBrands.Select(x => x.RawMaterialProviderId).ToList());
            if (!deleteResponse.IsSuccess)
                return deleteResponse;

            foreach (var rawMaterialProvider in editRawMaterialProviderBrands)
            {
                var editResponse = Repository.Update(rawMaterialProvider);
                if (!editResponse.IsSuccess)
                    return editResponse;
            }

            return new ObjectResponse<bool>(true, "Relacion editada exitosamente");

        }

        public ObjectResponse<bool> Update(List<RawMaterialProviderBrand> rawMaterialProviderBrands, List<int> rawMaterialProvidersId)
        {
            var currentRawMaterialProviderBrands = Get(rawMaterialProvidersId);
            if (!currentRawMaterialProviderBrands.IsSuccess)
                return new ObjectResponse<bool>(false, currentRawMaterialProviderBrands.Message);

            var rawMaterialProviderBrandsId = currentRawMaterialProviderBrands.Data.Select(x => x.RawMaterialProviderBrandId).ToList();
            var editRawMaterialProviderBrands = rawMaterialProviderBrands.Where(x => rawMaterialProviderBrandsId.Contains(x.RawMaterialProviderBrandId)).ToList();
            var addRawMaterialProviderBrands = rawMaterialProviderBrands.Where(x => x.RawMaterialProviderBrandId == 0).ToList();
            var deleteRawMaterialProviderBrands = currentRawMaterialProviderBrands.Data.Where(x => !rawMaterialProviderBrands.Select(y => y.RawMaterialProviderBrandId).Contains(x.RawMaterialProviderBrandId)).ToList();

            var actionResponse = RouteUpdateActions(editRawMaterialProviderBrands, addRawMaterialProviderBrands, deleteRawMaterialProviderBrands);
            if (actionResponse.Data)
                return actionResponse;

            return new ObjectResponse<bool>(true, "Relacion actualizada exitosamente");
        }

        public ObjectResponse<bool> Delete(List<int> rawMaterialProviderBrandsId)
        {
            foreach (var rawMaterialProviderBrandId in rawMaterialProviderBrandsId)
            {
                var  actionResponse = Repository.Delete(rawMaterialProviderBrandId);
                if (!actionResponse.IsSuccess)
                    return actionResponse;
            }

            return new ObjectResponse<bool>(true, "Eliminacion exitos");
        }

        public ObjectResponse<List<RawMaterialProviderBrand>> Get(List<int> rawMaterialProvidersId)
        {
            var rawMaterialProviderBrands = Repository.GetAll();
            if (!rawMaterialProviderBrands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrand>>(false, rawMaterialProviderBrands.Message);

            var rawMaterialProviderBrandsByRawMaterialId = rawMaterialProviderBrands.Data.Where(x => rawMaterialProvidersId.Contains(x.RawMaterialProviderId)).ToList();

            return new ObjectResponse<List<RawMaterialProviderBrand>>(true, "Consulta exitosa", rawMaterialProviderBrandsByRawMaterialId);
        }

        public ObjectResponse<List<RawMaterialProviderBrand>> GetAll(bool deleteItems) 
        {
            var rawMaterialProviderBrands = Repository.GetAll();
            if (!rawMaterialProviderBrands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrand>>(false, rawMaterialProviderBrands.Message);

            return new ObjectResponse<List<RawMaterialProviderBrand>>(true, "Consulta exitosa", rawMaterialProviderBrands.Data);

        }
    }
}
