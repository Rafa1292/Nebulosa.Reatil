using Business.Brands;
using Business.ModelsDTO;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Business.RawMaterialProviderBrands
{
    public class RouterRawMaterialProviderBrand
    {
        private readonly IRawMaterialProviderBrand _rawMaterialProviderBrand;
        private readonly RouterBrand _brand;


        public RouterRawMaterialProviderBrand(IRawMaterialProviderBrand rawMaterialProviderBrand, RouterBrand brand)
        {
            _rawMaterialProviderBrand = rawMaterialProviderBrand;
            _brand = brand;
        }

        public ObjectResponse<bool> Insert(RawMaterialProviderBrandDTO rawMaterialProviderBrandDTO, int rawMaterialProviderId)
        {

            var rawMaterialProviderBrand = MapperRawMaterialProviderBrand.MapFromDTO(rawMaterialProviderBrandDTO);
            rawMaterialProviderBrand = Finisher.FinishToDatabase(rawMaterialProviderBrand, rawMaterialProviderId);

            var validation = ValidateRawMaterialProviderBrand.ValidateToInsert(rawMaterialProviderBrand);
            if (!validation.IsSuccess)
                return validation;

            var actionResponse = _rawMaterialProviderBrand.Insert(rawMaterialProviderBrand);

            return actionResponse;
        }

        public ObjectResponse<bool> Update(RawMaterialProviderBrandDTO rawMaterialProviderBrandDTO)
        {
            var rawMaterialProviderBrand = MapperRawMaterialProviderBrand.MapFromDTO(rawMaterialProviderBrandDTO);
            rawMaterialProviderBrand = Finisher.FinishToDatabase(rawMaterialProviderBrand, rawMaterialProviderBrand.RawMaterialProviderId);

            var validation = ValidateRawMaterialProviderBrand.ValidateToInsert(rawMaterialProviderBrand);
            if (!validation.IsSuccess)
                return validation;

            var actionResponse = _rawMaterialProviderBrand.Update(rawMaterialProviderBrand);

            return actionResponse;
        }

        public ObjectResponse<bool> Delete(int rawMaterialProviderBrandId)
        {
            var actionResponse = _rawMaterialProviderBrand.Delete(rawMaterialProviderBrandId);

            return actionResponse;
        }

        public ObjectResponse<List<RawMaterialProviderBrandDTO>> Get(int rawMaterialProviderId)
        {
            var rawMaterialProviderBrands = _rawMaterialProviderBrand.GetAll(false);
            if (!rawMaterialProviderBrands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(false, rawMaterialProviderBrands.Message);

            rawMaterialProviderBrands.Data = rawMaterialProviderBrands.Data.Where(x => x.RawMaterialProviderId == rawMaterialProviderId).ToList();

            var brands = _brand.GetAll(false);
            if (!brands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(false, brands.Message);


            var rawMaterialProviderBrandsDTO = MapperRawMaterialProviderBrand.MapToDTO(rawMaterialProviderBrands.Data);
            rawMaterialProviderBrandsDTO = Finisher.FinishToGetAll(rawMaterialProviderBrandsDTO, brands.Data);


            return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(true, rawMaterialProviderBrands.Message, rawMaterialProviderBrandsDTO);
        }

        public ObjectResponse<List<RawMaterialProviderBrandDTO>> GetAll(bool deleteItems)
        {
            var rawMaterialProviderBrands = _rawMaterialProviderBrand.GetAll(deleteItems);
            if (!rawMaterialProviderBrands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(false, rawMaterialProviderBrands.Message);

            var brands = _brand.GetAll(false);
            if (!brands.IsSuccess)
                return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(false, brands.Message);


            var rawMaterialProviderBrandsDTO = MapperRawMaterialProviderBrand.MapToDTO(rawMaterialProviderBrands.Data);
            rawMaterialProviderBrandsDTO = Finisher.FinishToGetAll(rawMaterialProviderBrandsDTO, brands.Data);


            return new ObjectResponse<List<RawMaterialProviderBrandDTO>>(true, rawMaterialProviderBrands.Message, rawMaterialProviderBrandsDTO);
        }
    }
}
