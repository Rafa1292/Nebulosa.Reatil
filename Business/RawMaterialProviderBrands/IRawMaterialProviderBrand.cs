using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviderBrands
{
    public interface IRawMaterialProviderBrand
    {
        public ObjectResponse<bool> Insert(List<RawMaterialProviderBrand> rawMaterialProviderBrands);

        public ObjectResponse<bool> Update(List<RawMaterialProviderBrand> rawMaterialProviderBrands, List<int> rawMaterialProviderId);

        public ObjectResponse<bool> Delete(List<int> rawMaterialProviderBrandsId);

        public ObjectResponse<List<RawMaterialProviderBrand>> Get(List<int> rawMaterialProviderBrandsId);

        public ObjectResponse<List<RawMaterialProviderBrand>> GetAll(bool deleteItems);
    }
}
