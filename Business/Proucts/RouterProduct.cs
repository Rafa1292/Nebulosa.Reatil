using Business.ModelsDTO;
using Business.ProductTaxes;
using Business.SubCategories;
using Common;
using Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace Business.Proucts
{
    public class RouterProduct
    {
        private readonly IProduct _product;
        private readonly RouterProductTax _routerProductTax;
        private readonly RouterSubCategory _routerSubCategory

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
                return new ObjectResponse<bool>(false, "Error al obtener el Id del producto");

            var productTaxRealationship = _routerProductTax.Insert(productDTO.Taxes, productId.Data);
            if (!productTaxRealationship.IsSuccess)
                return productTaxRealationship;

            return new ObjectResponse<bool>(true, "Producto creado y relacionado correctamente");
        }

        public ObjectResponse<bool> Update(ProductDTO productDTO)
        {
            var product = MapperProduct.MapFromDTO(productDTO, new Product());
            product = Finisher.FinishToUpdate(product);
            var validation = ValidateProduct.ValidateToInsert(product, _product.GetAll(false).Data.ToList());

            if (!validation.IsSuccess)
                return validation;

            var updateProduct = _product.Update(product);

            if (!updateProduct.IsSuccess)
                return new ObjectResponse<bool>(false, "Error al actualizar el producto");

            var editRealationship = _routerProductTax.Update(productDTO.Taxes, productDTO.ProductId);
            if (!editRealationship.IsSuccess)
                return editRealationship;

            return new ObjectResponse<bool>(true, "Producto actualizado correctamente");
        }

        public ObjectResponse<bool> Delete(int productId)
        {
            var tryDeleteProduct = _product.Delete(productId);
            if (!tryDeleteProduct.IsSuccess)
                return tryDeleteProduct;

            var tryDeleteRelationship = _routerProductTax.Delete(productId);

            if (!tryDeleteRelationship.IsSuccess)
                return tryDeleteRelationship;


            return tryDeleteProduct;
        }

        public ObjectResponse<ProductDTO> Get(int productId)
        {
            var productSubCategory = _routerSubCategory.Get(productId);
            if (!productSubCategory.IsSuccess)
                return new ObjectResponse<ProductDTO>(false, productSubCategory.Message);

            var productTaxes = _routerProductTax.Get(productId);
            if (!productTaxes.IsSuccess)
                return new ObjectResponse<ProductDTO>(false, productTaxes.Message);

            var product = _product.Get(productId);
            if (!product.IsSuccess)
                return new ObjectResponse<ProductDTO>(false, product.Message);

            var productDTO = MapperProduct.MapToDTO(product.Data);
            productDTO = Finisher.FinishToGet(productDTO, productSubCategory.Data, productTaxes.Data);

            return new ObjectResponse<ProductDTO>(true, product.Message, productDTO);
        }

        public ObjectResponse<List<ProductDTO>> GetAll(bool deleteItems)
        {
            var productSubCategories = _routerSubCategory.GetAll(deleteItems);
            if (!productSubCategories.IsSuccess)
                return new ObjectResponse<List<ProductDTO>>(false, productSubCategories.Message);

            var productTaxes = _routerProductTax.GetAll(deleteItems);
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
