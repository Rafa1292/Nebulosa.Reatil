using Business.Preparations;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Preparations
{
    public class ImplementerPreparation : IPreparation
    {
        public ObjectResponse<List<Preparation>> GetAll(bool deleteItems)
        {
            var preparations = Repository.GetAll();

            if (preparations.IsSuccess && !deleteItems)
            {
                preparations.Data.Where(x => !x.Delete).ToList();
            }

            return preparations;
        }
    }
}
