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

        public ObjectResponse<bool> Insert(ProductTaxDTO productTaxDTO)
        {
            var productTax = MapperProductTax.MapFromDTO(productTaxDTO, new ProductTax());
            productTax = Finisher.FinishToInsert(productTax);
            var validation = ValidateProductTax.ValidateToInsert(productTax);

            if (!validation.IsSuccess)
                return validation;

            return _productTax.Insert(productTax);
        }

        public ObjectResponse<bool> Update(ProductTaxDTO productTaxDTO)
        {
            var currentProductTax = _productTax.Get(productTaxDTO.ProductTaxId);
            if (!currentProductTax.IsSuccess)
                return new ObjectResponse<bool>(false, currentProductTax.Message);

            var productTax = MapperProductTax.MapFromDTO(productTaxDTO, currentProductTax.Data);
            productTax = Finisher.FinishToUpdate(productTax);
            var validation = ValidateProductTax.ValidateToInsert(productTax);
            if (!validation.IsSuccess)
                return validation;

            return _productTax.Update(productTax);
        }

        public ObjectResponse<bool> Delete(int productTaxId)
        {
            return _productTax.Delete(productTaxId);
        }

        public ObjectResponse<ProductTaxDTO> Get(int productTaxID)
        {
            var productTax = _productTax.Get(productTaxID);

            if (!productTax.IsSuccess)
                return new ObjectResponse<ProductTaxDTO>(false, productTax.Message);

            var productTaxDTO = MapperProductTax.MapToDTO(productTax.Data);
            
            return new ObjectResponse<ProductTaxDTO>(true, productTax.Message, productTaxDTO);
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
