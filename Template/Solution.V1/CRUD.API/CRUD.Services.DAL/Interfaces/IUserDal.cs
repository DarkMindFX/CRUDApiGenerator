

using CRUD.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using CRUD.Services.Dal;

namespace CRUD.Services.Dal
{
    public interface IUserDal : IDalBase<User>
    {
        User Get(System.Int64? ID);

    }
}
