using Business.PreparationItems;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.PreparationItems
{
    public class ImplementerPreparationItem : IPreparationItem
    {
        public ObjectResponse<List<PreparationItem>> GetAll(bool deleteItems)
        {
            var preparationItems = Repository.GetAll();

            if (preparationItems.IsSuccess && !deleteItems)
            {
                preparationItems.Data.Where(x => !x.Delete).ToList();
            }

            return preparationItems;
        }
    }
}
