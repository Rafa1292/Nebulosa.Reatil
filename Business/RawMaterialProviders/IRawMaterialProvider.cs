using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviders
{
    public interface IRawMaterialProvider
    {
        public ObjectResponse<int> Insert(RawMaterialProvider rawMaterialProvider);

        public ObjectResponse<bool> Update(List<RawMaterialProvider> rawMaterialProvider, int rawMaterialId);

        public ObjectResponse<bool> Delete(List<int> rawMaterialProvidersId);

        public ObjectResponse<List<RawMaterialProvider>> GetByRawMaterial(int rawMaterialId);

        public ObjectResponse<List<RawMaterialProvider>> GetByProvider(int providerId);

        public ObjectResponse<List<RawMaterialProvider>> GetAll(bool deleteItems);
    }
}
