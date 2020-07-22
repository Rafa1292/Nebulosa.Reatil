using Business.ModelsDTO;
using Business.ProductTaxes;
using Business.SubCategories;
using Common;
using Common.Models;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace Business.Products
{
    public class RouterProduct
    {
        private readonly IProduct _product;
        private readonly RouterProductTax _productTax;
        private readonly RouterSubCategory _subCategory;

        public RouterProduct(IProduct product, RouterSubCategory subCategory, RouterProductTax productTax)
        {
            _product = product;
            _subCategory = subCategory;
            _productTax = productTax;
        }

        public ObjectResponse<bool> Insert(ProductDTO productDTO)
        {
            using (var scope = new TransactionScope())
            {
                var product = MapperProduct.MapFromDTO(productDTO, new Product());
                product = Finisher.FinishToInsert(product);
                var validation = ValidateProduct.ValidateToInsert(product, _product.GetAll(false).Data.ToList());

                if (!validation.IsSuccess)
                    return validation;

                var productId = _product.Insert(product);

                if (!productId.IsSuccess)
                    return new ObjectResponse<bool>(false, "Error al obtener el Id del producto");

                var productTaxRealationship = _productTax.Insert(productDTO.Taxes, productId.Data);
                if (!productTaxRealationship.IsSuccess)
                {
                    scope.Dispose();
                    return productTaxRealationship;
                }

                scope.Complete();
                return new ObjectResponse<bool>(true, "Producto creado y relacionado correctamente");
            }
        }

        public ObjectResponse<bool> Update(ProductDTO productDTO)
        {
            using (var scope = new TransactionScope())
            {
                var product = MapperProduct.MapFromDTO(productDTO, new Product());
                product = Finisher.FinishToUpdate(product);
                var validation = ValidateProduct.ValidateToInsert(product, _product.GetAll(false).Data.ToList());

                if (!validation.IsSuccess)
                    return validation;

                var updateProduct = _product.Update(product);

                if (!updateProduct.IsSuccess)
                    return new ObjectResponse<bool>(false, "Error al actualizar el producto");

                var editRealationship = _productTax.Update(productDTO.Taxes, productDTO.ProductId);
                if (!editRealationship.IsSuccess)
                {
                    scope.Dispose();
                    return editRealationship;
                }

                scope.Complete();
                return new ObjectResponse<bool>(true, "Producto actualizado correctamente");
            }
        }

        public ObjectResponse<bool> Delete(int productId, List<ProductTaxDTO> productTaxesDTO)
        {
            using (var scope = new TransactionScope())
            {
                var tryDeleteProduct = _product.Delete(productId);
                if (!tryDeleteProduct.IsSuccess)
                    return tryDeleteProduct;

                var productTaxes = MapperProductTax.MapFromDTO(productTaxesDTO, productId);

                var tryDeleteRelationship = _productTax.Delete(productTaxes);

                if (!tryDeleteRelationship.IsSuccess)
                {
                    scope.Dispose();
                    return tryDeleteRelationship;
                }

                scope.Complete();
                return tryDeleteProduct;
            }
        }

        public ObjectResponse<ProductDTO> Get(int productId)
        {
            var product = _product.Get(productId);
            if (!product.IsSuccess)
                return new ObjectResponse<ProductDTO>(false, product.Message);

            var productSubCategory = _subCategory.Get(product.Data.ProductSubCategoryId);
            if (!productSubCategory.IsSuccess)
                return new ObjectResponse<ProductDTO>(false, productSubCategory.Message);

            var productTaxes = _productTax.Get(productId);
            if (!productTaxes.IsSuccess)
                return new ObjectResponse<ProductDTO>(false, productTaxes.Message);

            var productDTO = MapperProduct.MapToDTO(product.Data);
            productDTO = Finisher.FinishToGet(productDTO, productSubCategory.Data, productTaxes.Data);

            return new ObjectResponse<ProductDTO>(true, product.Message, productDTO);
        }

        public ObjectResponse<List<ProductDTO>> GetAll(bool deleteItems)
        {
            var productSubCategories = _subCategory.GetAll(deleteItems);
            if (!productSubCategories.IsSuccess)
                return new ObjectResponse<List<ProductDTO>>(false, productSubCategories.Message);

            var productTaxes = _productTax.GetAll(deleteItems);
            if (!productTaxes.IsSuccess)
                return new ObjectResponse<List<ProductDTO>>(false, productTaxes.Message);


            var products = _product.GetAll(deleteItems);
            if (!products.IsSuccess)
                return new ObjectResponse<List<ProductDTO>>(false, products.Message);

            var productsDTO = MapperProduct.MapToDTO(products.Data);
            productsDTO = Finisher.FinishToGetAll(productsDTO, productSubCategories.Data, productTaxes.Data);

            return new ObjectResponse<List<ProductDTO>>(true, products.Message, productsDTO);
        }
    }
}
