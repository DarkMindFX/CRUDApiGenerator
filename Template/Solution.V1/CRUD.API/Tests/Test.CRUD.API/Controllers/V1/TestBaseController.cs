using PPT.PhotoPrint.API.Controllers.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test.E2E.API.Controllers.V1
{
    class TestBaseController
    {
        class BaseControllerTestWrapper : BaseController
        {
            private readonly PPT.Interfaces.Entities.User currentUser = new PPT.Interfaces.Entities.User { ID = 100001 };

            public override PPT.Interfaces.Entities.User CurrentUser
            {
                get
                {
                    return currentUser;
                }
            }

            public new void SetCreatedModifiedProperties(object obj, string propNameDate, string propNameID)
            {
                base.SetCreatedModifiedProperties(obj, propNameDate, propNameID);
            }

        }
        
    }
}
