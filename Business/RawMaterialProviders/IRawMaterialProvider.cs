using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterialProviders
{
    public interface IRawMaterialProvider
    {
        public ObjectResponse<bool> Insert(RawMaterialProvider rawMaterialProvider);

        public ObjectResponse<bool> Update(RawMaterialProvider rawMaterialProvider);

        public ObjectResponse<bool> Delete(int rawMaterialProviderId);

        public ObjectResponse<List<RawMaterialProvider>> GetByRawMaterial(int rawMaterialId);

        public ObjectResponse<List<RawMaterialProvider>> GetByProvider(int providerId);

        public ObjectResponse<List<RawMaterialProvider>> GetAll(bool deleteItems);
    }
}
