using Business.RawMaterials;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.RawMaterials
{
    public class ImplementerRawMaterial : IRawMaterial
    {
        public ObjectResponse<bool> Insert(RawMaterial rawMaterial)
        {
            return Repository.Insert(rawMaterial);
        }

        public ObjectResponse<bool> Update(RawMaterial rawMaterial)
        {
            return Repository.Update(rawMaterial);
        }

        public ObjectResponse<bool> Delete(int rawMaterialId)
        {
            return Repository.Delete(rawMaterialId);
        }

        public ObjectResponse<RawMaterial> Get(int rawMaterialId)
        {
            return Repository.Get(rawMaterialId);
        }

        public ObjectResponse<List<RawMaterial>> GetAll(bool deleteItems)
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
