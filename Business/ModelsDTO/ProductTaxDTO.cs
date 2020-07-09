using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ModelsDTO
{
    public class ProductTaxDTO
    {
        public int ProductTaxId { get; set; }

        public int ProductId { get; set; }

        public bool Delete { get; set; }

        public int TaxId { get; set; }
    }
}
