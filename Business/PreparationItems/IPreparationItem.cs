using Business.ModelsDTO;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.PreparationItems
{
    public interface IPreparationItem
    {
        public ObjectResponse<bool> Insert(PreparationItem preparationItem);

        public ObjectResponse<List<PreparationItem>> GetAll(bool deleteItems);
    }
}
