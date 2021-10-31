using System;
using System.Collections.Generic;
using System.Text;

namespace PPT.PhotoPrint.API.Dal
{
    public interface IDalBase<TEntity> 
    {
        IList<TEntity> GetAll();

        TEntity Insert(TEntity entity);

        TEntity Update(TEntity entity);

    }
}
