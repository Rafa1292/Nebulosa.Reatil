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
        public ObjectResponse<bool> Insert(RawMaterialProviderBrand rawMaterialProviderBrand)
        {
            var response = Repository.Insert(rawMaterialProviderBrand);

            return response;
        }

        public ObjectResponse<bool> Update(RawMaterialProviderBrand rawMaterialProviderBrand)
        {
            var response = Repository.Update(rawMaterialProviderBrand);

            return response;
        }

        public ObjectResponse<bool> Delete(int rawMaterialProviderBrandId)
        {
            var actionResponse = Repository.Delete(rawMaterialProviderBrandId);
            return actionResponse;
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
