using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Providers
{
    public interface IProvider
    {
        public ObjectResponse<bool> Insert(Provider provider);

        public ObjectResponse<bool> Update(Provider provider);

        public ObjectResponse<bool> Delete(int providerId);

        public ObjectResponse<Provider> Get(int providerId);

        public ObjectResponse<IEnumerable<Provider>> GetAll(bool deleteItems);
    }
}
