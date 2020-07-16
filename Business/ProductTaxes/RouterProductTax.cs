using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

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
            using (var scope = new TransactionScope())
            {
                var productTaxList = MapperProductTax.MapFromDTO(productTaxesDTO, productId);
                productTaxList = Finisher.FinishToInsert(productTaxList);
                var validation = ValidateProductTax.ValidateToInsert(productTaxList);

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _productTax.Insert(productTaxList, productId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(List<ProductTaxDTO> productTaxesDTO, int productId)
        {
            using (var scope = new TransactionScope())
            {
                var productTaxList = MapperProductTax.MapFromDTO(productTaxesDTO, productId);
                productTaxList = Finisher.FinishToUpdate(productTaxList);
                var validation = ValidateProductTax.ValidateToInsert(productTaxList);

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _productTax.Update(productTaxList, productId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(List<ProductTax> productTaxes)
        {
            using (var scope = new TransactionScope())
            { 
                var actionResponse = _productTax.Delete(productTaxes);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
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
