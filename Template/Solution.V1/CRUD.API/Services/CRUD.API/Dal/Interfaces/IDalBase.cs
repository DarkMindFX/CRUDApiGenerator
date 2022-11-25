using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.API.Dal
{
    public interface IDalBase<TEntity> 
    {
        IList<TEntity> GetAll();

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

    }
}
