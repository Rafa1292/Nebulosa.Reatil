using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

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
            using (var scope = new TransactionScope())
            {
                var tax = MapperTax.MapFromDTO(taxDTO, new Tax());
                tax = Finisher.FinishToInsert(tax);
                var validation = ValidateTax.ValidateToInsert(tax);

                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _tax.Insert(tax);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Update(TaxDTO taxDTO)
        {
            using (var scope = new TransactionScope())
            {
                var currentTax = _tax.Get(taxDTO.TaxId);
                if (!currentTax.IsSuccess)
                    return new ObjectResponse<bool>(false, currentTax.Message);

                var tax = MapperTax.MapFromDTO(taxDTO, currentTax.Data);
                tax = Finisher.FinishToUpdate(tax);
                var validation = ValidateTax.ValidateToInsert(tax);
                if (!validation.IsSuccess)
                    return validation;

                var actionResponse = _tax.Update(tax);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
        }

        public ObjectResponse<bool> Delete(int taxId)
        {
            using (var scope = new TransactionScope())
            {
                var actionResponse = _tax.Delete(taxId);
                if (actionResponse.IsSuccess)
                    scope.Complete();

                return actionResponse;
            }
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
