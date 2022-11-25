

using CRUD.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUD.API.Dal
{
    public interface IUserDal : IDalBase<User>
    {
        User Get(System.Int64? ID);

    }
}
