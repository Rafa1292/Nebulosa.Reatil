using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.ProductTaxes
{
    public class RouterProductTax
    {
        private readonly IProductTax _productTax;

        public RouterProductTax(IProductTax productTax)
        {
            _productTax = productTax;
        }

        public ObjectResponse<bool> Insert(List<ProductTaxDTO> productTaxesDTO, int productId)
        {
            var productTaxList = MapperProductTax.MapFromDTO(productTaxesDTO);
            productTaxList = Finisher.FinishToInsert(productTaxList);
            var validation = ValidateProductTax.ValidateToInsert(productTaxList);

            if (!validation.IsSuccess)
                return validation;

            return _productTax.Insert(productTaxList, productId);
        }

        public ObjectResponse<bool> Update(List<ProductTaxDTO> productTaxesDTO, int productId)
        {
            var productTaxList = MapperProductTax.MapFromDTO(productTaxesDTO);
            productTaxList = Finisher.FinishToUpdate(productTaxList);
            var validation = ValidateProductTax.ValidateToInsert(productTaxList);

            if (!validation.IsSuccess)
                return validation;

            return _productTax.Update(productTaxList, productId);
        }

        public ObjectResponse<bool> Delete(List<ProductTax> productTaxes)
        {
            return _productTax.Delete(productTaxes);
        }

        public ObjectResponse<List<ProductTaxDTO>> Get(int productID)
        {
            var productTax = _productTax.Get(productID, false);

            if (!productTax.IsSuccess)
                return new ObjectResponse<List<ProductTaxDTO>>(false, productTax.Message);

            var productTaxDTO = MapperProductTax.MapToDTO(productTax.Data);

            return new ObjectResponse<List<ProductTaxDTO>>(true, productTax.Message, productTaxDTO);
        }

        public ObjectResponse<List<ProductTaxDTO>> GetAll(bool deleteItems)
        {
            var productTaxes = _productTax.GetAll(deleteItems);

            if (!productTaxes.IsSuccess)
                return new ObjectResponse<List<ProductTaxDTO>>(false, productTaxes.Message);

            var productSubCategoriesDTO = MapperProductTax.MapToDTO(productTaxes.Data.ToList());

            return new ObjectResponse<List<ProductTaxDTO>>(true, productTaxes.Message, productSubCategoriesDTO);
        }
    }
}
