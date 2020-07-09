using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Taxes
{
    public class RouterTax
    {
        private readonly ITax _tax;

        public RouterTax(ITax tax)
        {
            _tax = tax;
        }

        public ObjectResponse<bool> Insert(TaxDTO taxDTO)
        {
            var tax = MapperTax.MapFromDTO(taxDTO, new Tax());
            tax = Finisher.FinishToInsert(tax);
            var validation = ValidateTax.ValidateToInsert(tax);

            if (!validation.IsSuccess)
                return validation;

            return _tax.Insert(tax);
        }

        public ObjectResponse<bool> Update(TaxDTO taxDTO)
        {
            var currentTax = _tax.Get(taxDTO.TaxId);
            if (!currentTax.IsSuccess)
                return new ObjectResponse<bool>(false, currentTax.Message);

            var tax = MapperTax.MapFromDTO(taxDTO, currentTax.Data);
            tax = Finisher.FinishToUpdate(tax);
            var validation = ValidateTax.ValidateToInsert(tax);
            if (!validation.IsSuccess)
                return validation;

            return _tax.Update(tax);
        }

        public ObjectResponse<bool> Delete(int taxId)
        {
            return _tax.Delete(taxId);
        }

        public ObjectResponse<TaxDTO> Get(int taxId)
        {
            var tax = _tax.Get(taxId);

            if (!tax.IsSuccess)
                return new ObjectResponse<TaxDTO>(false, tax.Message);

            var taxDTO = MapperTax.MapToDTO(tax.Data);

            return new ObjectResponse<TaxDTO>(true, tax.Message, taxDTO);
        }

        public ObjectResponse<List<TaxDTO>> GetAll(bool deleteItems)
        {
            var taxes = _tax.GetAll(deleteItems);

            if (!taxes.IsSuccess)
                return new ObjectResponse<List<TaxDTO>>(false, taxes.Message);

            var taxesDTO = MapperTax.MapToDTO(taxes.Data.ToList());

            return new ObjectResponse<List<TaxDTO>>(true, taxes.Message, taxesDTO);
        }
    }
}
