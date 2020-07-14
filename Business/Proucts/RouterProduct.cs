using Business.ModelsDTO;
using Business.ProductTaxes;
using Business.SubCategories;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Proucts
{
    public class RouterProduct
    {
        private readonly IProduct _product;
        private readonly RouterSubCategory _routerSubCategory;
        private readonly RouterProductTax _routerProductTax;


        public RouterProduct(IProduct product, RouterSubCategory routerSubCategory, RouterProductTax routerProductTax)
        {
            _product = product;
            _routerSubCategory = routerSubCategory;
            _routerProductTax = routerProductTax;
        }

        public ObjectResponse<bool> Insert(ProductDTO productDTO)
        {
            var product = MapperProduct.MapFromDTO(productDTO, new Product());
            product = Finisher.FinishToInsert(product);
            var validation = ValidateProduct.ValidateToInsert(product, _product.GetAll(false).Data.ToList());

            if (!validation.IsSuccess)
                return validation;

            var productId = _product.Insert(product);

            if (!productId.IsSuccess)
                return productId;

            _routerProductTax.Insert();

            return ;
        }

        public ObjectResponse<bool> Update(ProductDTO productDTO)
        {
            var currentSubCategory = _subCategory.Get(productDTO.ProductSubCategoryId);
            if (!currentSubCategory.IsSuccess)
                return new ObjectResponse<bool>(false, currentSubCategory.Message);

            var subCategory = MapperSubCategory.MapFromDTO(productDTO, currentSubCategory.Data);
            subCategory = Finisher.FinishToUpdate(subCategory);
            var validation = ValidateSubCategory.ValidateToInsert(subCategory, _subCategory.GetAll(false).Data.ToList());
            if (!validation.IsSuccess)
                return validation;

            return _subCategory.Update(subCategory);
        }

        public ObjectResponse<bool> Delete(int productId)
        {
            return _subCategory.Delete(productId);
        }

        public ObjectResponse<ProductDTO> Get(int productId)
        {
            var productSubCategory = _subCategory.Get(productId);

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

        public ObjectResponse<List<ProductDTO>> GetAll(bool deleteItems)
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
