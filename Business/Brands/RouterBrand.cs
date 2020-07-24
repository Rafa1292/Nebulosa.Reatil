using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Business.Brands
{
    public class RouterBrand
    {
        private readonly IBrand _brand;

        public RouterBrand(IBrand brand)
        {
            _brand = brand;
        }

        public ObjectResponse<bool> Insert(BrandDTO brandDTO)
        {
            using (var scope = new TransactionScope())
            {
                var brand = MapperBrand.MapFromDTO(brandDTO, new Brand());
                brand = Finisher.FinishToInsert(brand);
                var validation = ValidateBrand.ValidateToInsert(brand, _brand.GetAll(false).Data);

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _brand.Insert(brand);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(BrandDTO brandDTO)
        {
            using (var scope = new TransactionScope())
            {
                var currentBrand = _brand.Get(brandDTO.BrandId);
                if (!currentBrand.IsSuccess)
                    return new ObjectResponse<bool>(false, currentBrand.Message);

                var brand = MapperBrand.MapFromDTO(brandDTO, currentBrand.Data);
                brand = Finisher.FinishToUpdate(brand);
                var validation = ValidateBrand.ValidateToInsert(brand, _brand.GetAll(false).Data);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _brand.Update(brand);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int brandId)
        {
            using (var scope = new TransactionScope())
            {
                //var rawMaterials = _brand.GetAll(false);
                //if (!rawMaterials.IsSuccess)
                //    return new ObjectResponse<bool>(false, rawMaterials.Message);

                //var relationship = ValidateBrand.ValidateToDelete(brandId, rawMaterials.Data);
                //if (!relationship.IsSuccess)
                //    return relationship;

                var actionResponse = _brand.Delete(brandId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<BrandDTO> Get(int brandId)
        {
            var brandResponse = _brand.Get(brandId);

            if (!brandResponse.IsSuccess)
                return new ObjectResponse<BrandDTO>(false, brandResponse.Message);

            var brandDTO = MapperBrand.MapToDTO(brandResponse.Data);
            //brandDTO = Finisher.FinishToGet(brandDTO, _subCategory.GetAll(false).Data);

            return new ObjectResponse<BrandDTO>(true, brandResponse.Message, brandDTO);
        }

        public ObjectResponse<List<BrandDTO>> GetAll(bool deleteItems)
        {
            var brandsResponse = _brand.GetAll(deleteItems);
            if (!brandsResponse.IsSuccess)
                return new ObjectResponse<List<BrandDTO>>(false, brandsResponse.Message);

            var brandsDTO = MapperBrand.MapToDTO(brandsResponse.Data);
            //brandDTO = Finisher.FinishToGet(brandDTO, _subCategory.GetAll(false).Data);



            return new ObjectResponse<List<BrandDTO>>(true, brandsResponse.Message, brandsDTO);
        }
    }
}
