using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Measures
{
    public class MapperMeasure
    {
        public static Measure MapFromDTO(MeasureDTO measureDTO, Measure measure)
        {
            measure.MeasureId = measureDTO.MeasureId;
            measure.Name = measureDTO.Name;

            return measure;
        }

        public static MeasureDTO MapToDTO(Measure measure)
        {
            MeasureDTO measureDTO = new MeasureDTO()
            {
                MeasureId = measure.MeasureId,
                Name = measure.Name                
            };

            return measureDTO;
        }

        public static List<MeasureDTO> MapToDTO(List<Measure> measures)
        {
            List<MeasureDTO> measuresDTO = new List<MeasureDTO>();

            measures.ForEach(x => measuresDTO.Add(
                new MeasureDTO()
                {
                    MeasureId = x.MeasureId,
                    Name = x.Name
                }));

            return measuresDTO;
        }
    }
}
