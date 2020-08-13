using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Preparations
{
    public class MapperPreparation
    {
        public static List<PreparationDTO> MapToDTO(List<Preparation> preparations)
        {
            var preparationsDTO = new List<PreparationDTO>();

            preparations.ForEach(x =>
                preparationsDTO.Add(
                    new PreparationDTO()
                    {
                        Cost = x.Cost,
                        Weight = x.Weight,
                        Description = x.Description,
                        Name = x.Name,
                        PreparationId = x.PreparationId
                    }));

            return preparationsDTO;
        }
    }
}
