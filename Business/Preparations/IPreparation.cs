using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Preparations
{
    public interface IPreparation
    {
        public ObjectResponse<int> Insert(Preparation preparation);

        public ObjectResponse<List<Preparation>> GetAll(bool deleteItems);

    }
}
