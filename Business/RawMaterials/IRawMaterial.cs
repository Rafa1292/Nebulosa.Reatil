using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.RawMaterials
{
    public interface IRawMaterial
    {
        public ObjectResponse<bool> Insert(RawMaterial rawMaterial);

        public ObjectResponse<bool> Update(RawMaterial rawMaterial);

        public ObjectResponse<bool> Delete(int rawMaterialId);

        public ObjectResponse<RawMaterial> Get(int rawMaterialId);


        public ObjectResponse<List<RawMaterial>> GetAll(bool deleteItems);
    }
}
