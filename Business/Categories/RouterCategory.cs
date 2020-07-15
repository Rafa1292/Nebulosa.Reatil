using Business.ModelsDTO;
using Business.SubCategories;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Categories
{
    public class RouterCategory
    {
        private readonly ICategory _category;
        private readonly RouterSubCategory _subCategory;
 
        public RouterCategory(ICategory category, RouterSubCategory routerSubCategory)
        {
            _category = category;
            _subCategory = routerSubCategory;
        }

        public ObjectResponse<bool> Insert(ProductCategoryDTO productCategoryDTO)
        {
            var category = MapperCategory.MapFromDTO(productCategoryDTO, new ProductCategory());
            category = Finisher.FinishToInsert(category);
            var validation = ValidateCategory.ValidateToInsert(category, _category.GetAll(false).Data.ToList());

            if (!validation.IsSuccess)
                return validation;

            return _category.Insert(category);
        }

        public ObjectResponse<bool> Update(ProductCategoryDTO productCategoryDTO)
        {
            var currentCategory = _category.Get(productCategoryDTO.ProductCategoryId);
            if (!currentCategory.IsSuccess)
                return new ObjectResponse<bool>(false, currentCategory.Message);

            var category = MapperCategory.MapFromDTO(productCategoryDTO , currentCategory.Data);
            category = Finisher.FinishToUpdate(category);
            var validation = ValidateCategory.ValidateToInsert(category, _category.GetAll(false).Data.ToList());
            if (!validation.IsSuccess)
                return validation;

            return _category.Update(category);
        }

        public ObjectResponse<bool> Delete(int productCategoryId)
        {
            return _category.Delete(productCategoryId);
        }

        public ObjectResponse<ProductCategoryDTO> Get(int productCategoryId)
        {
            var productCategoryResponse = _category.Get(productCategoryId);

            if (!productCategoryResponse.IsSuccess)
                return new ObjectResponse<ProductCategoryDTO>(false, productCategoryResponse.Message);

            var productCategoryDTO = MapperCategory.MapToDTO(productCategoryResponse.Data);
            productCategoryDTO = Finisher.FinishToGet(productCategoryDTO, _subCategory.GetAll(false).Data);

            return new ObjectResponse<ProductCategoryDTO>(true, productCategoryResponse.Message, productCategoryDTO);
        }

        public ObjectResponse<List<ProductCategoryDTO>> GetAll(bool deleteItems)
        {
            var productCategoriesResponse = _category.GetAll(deleteItems);
            if (!productCategoriesResponse.IsSuccess)
                return new ObjectResponse<List<ProductCategoryDTO>>(false, productCategoriesResponse.Message);

            var productSubCategoriesResponse = _subCategory.GetAll(deleteItems);
            if (!productSubCategoriesResponse.IsSuccess)
                return new ObjectResponse<List<ProductCategoryDTO>>(false, productSubCategoriesResponse.Message);

            var productCategoriesDTO = MapperCategory.MapToDTO(productCategoriesResponse.Data.ToList());
            productCategoriesDTO = Finisher.FinishToGetAll(productCategoriesDTO, productSubCategoriesResponse.Data);

            return new ObjectResponse<List<ProductCategoryDTO>>(true, productCategoriesResponse.Message, productCategoriesDTO);
        }
    }
}
