using Business.Brands;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Brands
{
    public class ImplementerBrand : IBrand
    {
        public ObjectResponse<bool> Insert(Brand brand)
        {
            return Repository.Insert(brand);
        }

        public ObjectResponse<bool> Update(Brand brand)
        {
            return Repository.Update(brand);
        }

        public ObjectResponse<bool> Delete(int brandId)
        {
            return Repository.Delete(brandId);
        }

        public ObjectResponse<Brand> Get(int brandId)
        {
            return Repository.Get(brandId);
        }

        public ObjectResponse<List<Brand>> GetAll(bool deleteItems)
        {
            var brands = Repository.GetAll();

            if (!brands.IsSuccess)
                return brands;

            if (!deleteItems)
                brands.Data = brands.Data.ToList().Where(x => !x.Delete).ToList();

            return brands;
        }
    }
}
