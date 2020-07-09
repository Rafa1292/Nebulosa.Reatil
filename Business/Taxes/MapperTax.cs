using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Taxes
{
    public class MapperTax
    {
        public static Tax MapFromDTO(TaxDTO taxDTO, Tax tax)
        {
            tax.TaxId = taxDTO.TaxId;
            tax.Name = taxDTO.Name;
            tax.Percentage = taxDTO.Percentage;

            return tax;
        }

        public static TaxDTO MapToDTO(Tax tax)
        {
            TaxDTO taxDTO = new TaxDTO()
            {
                TaxId = tax.TaxId,
                Name = tax.Name,
                Percentage = tax.Percentage
            };

            return taxDTO;
        }

        public static List<TaxDTO> MapToDTO(List<Tax> taxes)
        {
            List<TaxDTO> taxesDTO = new List<TaxDTO>();

            taxes.ForEach(x => taxesDTO.Add(
                new TaxDTO()
                {
                    TaxId = x.TaxId,
                    Name = x.Name,
                    Percentage = x.Percentage
                }));

            return taxesDTO;
        }
    }
}
