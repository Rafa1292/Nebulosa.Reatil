using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Products
{
    public class ValidateProduct
    {
        public static ObjectResponse<bool> ValidateToInsert(Product product, List<Product> products)
        {
            bool validateNullName = String.IsNullOrWhiteSpace(product.Name);

            if (!validateNullName)
                return new ObjectResponse<bool>(false, "El nombre no puede ser nulo");

            bool validateNullSubCategoryId = product.ProductSubCategoryId > 0 ? true : false;

            if (!validateNullSubCategoryId)
                return new ObjectResponse<bool>(false, "La subCategoria no puede ser nula");


            bool NameExist = products
                .Where(x => x.ProductId != product.ProductId )
                .Select(x => x.Name.ToLower())
                .Contains(product.Name.ToLower());

            if (NameExist)
                return new ObjectResponse<bool>(false, "Este nombre ya existe");



            return new ObjectResponse<bool>(true, "Producto validado");
        }
    }
}
