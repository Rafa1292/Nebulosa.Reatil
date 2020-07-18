using Business.Categories;
using Business.ModelsDTO;
using Business.Products;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.SubCategories
{
    public class RouterSubCategory
    {
        private readonly ISubCategory _subCategory;
        private readonly ICategory _category;
        private readonly IProduct _product;

        public RouterSubCategory(ISubCategory subCategory, ICategory category, IProduct product)
        {
            _product = product;
            _subCategory = subCategory;
            _category = category;
        }

        public ObjectResponse<bool> Insert(ProductSubCategoryDTO productSubCategoryDTO)
        {
            using (var scope = new TransactionScope())
            {
                var subCategory = MapperSubCategory.MapFromDTO(productSubCategoryDTO, new ProductSubCategory());
                subCategory = Finisher.FinishToInsert(subCategory);
                var validation = ValidateSubCategory.ValidateToInsert(subCategory, _subCategory.GetAll(false).Data.ToList());

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _subCategory.Insert(subCategory);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(ProductSubCategoryDTO productSubCategoryDTO)
        {
            using (var scope = new TransactionScope())
            {
                var currentSubCategory = _subCategory.Get(productSubCategoryDTO.ProductSubCategoryId);
                if (!currentSubCategory.IsSuccess)
                    return new ObjectResponse<bool>(false, currentSubCategory.Message);

                var subCategory = MapperSubCategory.MapFromDTO(productSubCategoryDTO, currentSubCategory.Data);
                subCategory = Finisher.FinishToUpdate(subCategory);
                var validation = ValidateSubCategory.ValidateToInsert(subCategory, _subCategory.GetAll(false).Data.ToList());
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _subCategory.Update(subCategory);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int productSubCategoryId)
        {
            using (var scope = new TransactionScope())
            {
                var productRelationship = _product.GetAll(false);
                if (!productRelationship.IsSuccess)
                    return new ObjectResponse<bool>(false, productRelationship.Message);

                var validate = ValidateSubCategory.ValidateToDelete(productSubCategoryId, productRelationship.Data);
                if (!validate.IsSuccess)
                    return validate;

                var actionResponse = _subCategory.Delete(productSubCategoryId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<ProductSubCategoryDTO> Get(int productSubCategoryId)
        {
            var productSubCategory = _subCategory.Get(productSubCategoryId);

            if (!productSubCategory.IsSuccess)
                return new ObjectResponse<ProductSubCategoryDTO>(false, productSubCategory.Message);

            var productSubCategoryDTO = MapperSubCategory.MapToDTO(productSubCategory.Data);
            var productCategory = _category.Get(productSubCategoryDTO.ProductCategoryId);

            if (!productCategory.IsSuccess)
                return new ObjectResponse<ProductSubCategoryDTO>(false, "No se pudo obtener la categoria asociada");

            var productCategoryDTO = MapperCategory.MapToDTO(productCategory.Data);
            productSubCategoryDTO = Finisher.FinishToGet(productSubCategoryDTO, productCategoryDTO);

            return new ObjectResponse<ProductSubCategoryDTO>(true, productSubCategory.Message, productSubCategoryDTO);
        }

        public ObjectResponse<List<ProductSubCategoryDTO>> GetAll(bool deleteItems)
        {
            var productSubCategories = _subCategory.GetAll(deleteItems);

            if (!productSubCategories.IsSuccess)
                return new ObjectResponse<List<ProductSubCategoryDTO>>(false, productSubCategories.Message);

            var productSubCategoriesDTO = MapperSubCategory.MapToDTO(productSubCategories.Data.ToList());

            var productCategories = _category.GetAll(deleteItems);

            if (!productCategories.IsSuccess)
                return new ObjectResponse<List<ProductSubCategoryDTO>>(false, "No se pudieron obtener las categorias asociadas");

            var productCategoriesDTO = MapperCategory.MapToDTO(productCategories.Data.ToList());
            productSubCategoriesDTO = Finisher.FinishToGetAll(productSubCategoriesDTO, productCategoriesDTO);

            return new ObjectResponse<List<ProductSubCategoryDTO>>(true, productSubCategories.Message, productSubCategoriesDTO);
        }
    }
}
