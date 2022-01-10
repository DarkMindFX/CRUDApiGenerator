using PPT.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PPT.Services.Dal
{
    public class DalBaseImpl<TEntity, TDal> : IDalBase<TEntity> where TDal : PPT.Interfaces.IDalBase<TEntity>
    {
        protected TDal _dalImpl;

        protected DalBaseImpl(TDal dalImpl)
        {
            _dalImpl = dalImpl;
        }

        public TEntity Update(TEntity entity)
        {
            return _dalImpl.Update(entity);
        }

        public IList<TEntity> GetAll()
        {
            return _dalImpl.GetAll();
        }

        public TEntity Insert(TEntity entity)
        {
            return _dalImpl.Insert(entity);
        }
    }
}
