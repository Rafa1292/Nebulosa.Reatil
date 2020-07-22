using Business.ModelsDTO;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Measures
{
    public class Finisher
    {
        public static Measure FinishToInsert(Measure measure)
        {
            measure.DateCreate = DateTime.Now;
            measure.DateUpdate = DateTime.Now;
            measure.UserCreate = "";//pendiente de implementar
            measure.UserUpdate = "";//pendiente de implementar

            return measure;
        }

        public static Measure FinishToUpdate(Measure measure)
        {
            measure.DateUpdate = DateTime.Now;
            measure.UserUpdate = "";//pendiente de implementar

            return measure;
        }

    }
}
