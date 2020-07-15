using Business.ProductTaxes;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.ProductTaxes
{
    public class ImplementerProductTax : IProductTax
    {
        #region Metodos
        public ObjectResponse<bool> Insert(List<ProductTax> productTaxes, int productId)
        {
            foreach (var productTax in productTaxes)
            {
                var CheckPreviousRelationship = WasDeleted(productTax, productId);
                if (CheckPreviousRelationship.IsSuccess)
                {
                    var currentTax = CheckPreviousRelationship.Data;
                    currentTax.Delete = false;
                    return Repository.Update(currentTax);
                }

                var response = Repository.Insert(productTax);
                if (!response.IsSuccess)
                    return response;
            }

            return new ObjectResponse<bool>(true, "Relacion exitosa");
        }

        public ObjectResponse<bool> Update(List<ProductTax> productTaxes, int productId)
        {
            var currentTaxes = Get(productId, false);

            if (!currentTaxes.IsSuccess)
                return new ObjectResponse<bool>(false, "No se puede actualizar en este momento");

            var currentTaxesId = currentTaxes.Data.Select(x => x.ProductTaxId);
            var newTaxesId = productTaxes.Select(x => x.ProductTaxId);

            var taxesToInsert = productTaxes.Where(x => !currentTaxesId.Contains(x.ProductTaxId)).ToList();
            var taxesToDelete = currentTaxes.Data.Where(x => !newTaxesId.Contains(x.ProductTaxId)).ToList();

            var tryInsert = Insert(taxesToInsert, productId);

            if (!tryInsert.IsSuccess)
                return tryInsert;

            var tryDelete = Delete(taxesToDelete);

            if (!tryDelete.IsSuccess)
                return tryDelete;

            return new ObjectResponse<bool>(true, "Relacion actualizada");
        }

        public ObjectResponse<bool> Delete(int productId)
        {
            var productTaxes = Get(productId, false);

            foreach (var productTax in productTaxes.Data)
            {
                var response = Repository.Delete(productTax.ProductTaxId);
                if (!response.IsSuccess)
                    return response;
            }
            return new ObjectResponse<bool>(true, "Relacion eliminada");
        }

        public ObjectResponse<List<ProductTax>> Get(int productId, bool deleteItems)
        {
            var taxes = Repository.Get(productId);

            if (!taxes.IsSuccess)
                return taxes;

            if (!deleteItems)
                taxes.Data = taxes.Data.Where(x => !x.Delete).ToList();

            return taxes;

        }

        public ObjectResponse<List<ProductTax>> GetAll(bool deleteItems)
        {
            var productTaxes = Repository.GetAll();

            if (!productTaxes.IsSuccess)
                return productTaxes;

            if (!deleteItems)
                productTaxes.Data = productTaxes.Data.ToList().Where(x => !x.Delete).ToList();

            return productTaxes;
        }

        #endregion

        public ObjectResponse<ProductTax> WasDeleted(ProductTax productTax, int productId)
        {
            var currentTaxes = GetAll(true);

            if (!currentTaxes.IsSuccess)
                return new ObjectResponse<ProductTax>(false, currentTaxes.Message);

            currentTaxes.Data = currentTaxes.Data.Where(x => x.ProductId == productId).ToList();

            if (currentTaxes.Data.Select(x => x.TaxId).Contains(productTax.TaxId))
            {
                var currentTax = currentTaxes.Data.ToList().Find(x => x.TaxId == productTax.TaxId);
                return new ObjectResponse<ProductTax>(true, "Impuesto anteriormente relacionado", currentTax);
            }

            return new ObjectResponse<ProductTax>(false, "Impuesto no relacionado", null);
        }

    }
}
