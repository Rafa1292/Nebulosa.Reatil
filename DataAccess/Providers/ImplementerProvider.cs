using Business.Providers;
using Common;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Providers
{
    public class ImplementerProvider : IProvider
    {
        #region Metodos
        public ObjectResponse<bool> Insert(Provider provider)
        {
            return Repository.Insert(provider);
        }

        public ObjectResponse<bool> Update(Provider provider)
        {
            return Repository.Update(provider);
        }

        public ObjectResponse<bool> Delete(int providerId)
        {
            return Repository.Delete(providerId);
        }

        public ObjectResponse<Provider> Get(int providerId)
        {
            return Repository.Get(providerId);
        }

        public ObjectResponse<List<Provider>> GetAll(bool deleteItems)
        {
            var providers = Repository.GetAll();

            if (!providers.IsSuccess)
                return providers;

            if (!deleteItems)
                providers.Data = providers.Data.ToList().Where(x => !x.Delete).ToList();

            return providers;
        }

        #endregion
    }
}
