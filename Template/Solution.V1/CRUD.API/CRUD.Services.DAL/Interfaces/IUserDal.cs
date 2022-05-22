

using PPT.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using PPT.Services.Dal;

namespace PPT.Services.Dal
{
    public interface IUserDal : IDalBase<User>
    {
        User Get(System.Int64? ID);

    }
}
