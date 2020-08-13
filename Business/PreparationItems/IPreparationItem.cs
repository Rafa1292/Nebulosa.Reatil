using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.PreparationItems
{
    public interface IPreparationItem
    {
        public ObjectResponse<List<PreparationItem>> GetAll(bool deleteItems);
    }
}
