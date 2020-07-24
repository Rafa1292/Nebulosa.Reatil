using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Brands
{
    public interface IBrand
    {
        public ObjectResponse<bool> Insert(Brand brand);

        public ObjectResponse<bool> Update(Brand brand);

        public ObjectResponse<bool> Delete(int brandId);

        public ObjectResponse<Brand> Get(int brandId);

        public ObjectResponse<List<Brand>> GetAll(bool deleteItems);
    }
}
