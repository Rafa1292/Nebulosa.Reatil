using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviderBrands
{
    public interface IRawMaterialProviderBrand
    {
        public ObjectResponse<bool> Insert(RawMaterialProviderBrand rawMaterialProviderBrand);

        public ObjectResponse<bool> Update(RawMaterialProviderBrand rawMaterialProviderBrand);

        public ObjectResponse<bool> Delete(int rawMaterialProviderBrandId);

        public ObjectResponse<List<RawMaterialProviderBrand>> Get(List<int> rawMaterialProviderBrandsId);

        public ObjectResponse<List<RawMaterialProviderBrand>> GetAll(bool deleteItems);
    }
}
