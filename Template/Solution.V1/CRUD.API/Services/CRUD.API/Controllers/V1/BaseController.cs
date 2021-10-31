using PPT.Interfaces.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace PPT.PhotoPrint.API.Controllers.V1
{
    public class BaseController : ControllerBase
    {
        public virtual User CurrentUser
        {
            get
            {
                return HttpContext.Items["User"] as User;
            }
        }

        protected void SetCreatedModifiedProperties(object obj, string propNameDate, string propNameID)
        {
            if(propNameDate != null && obj.GetType().GetProperty(propNameDate) != null)
            {
                obj.GetType().GetProperty(propNameDate,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.Instance).SetValue(obj, DateTime.UtcNow, null);
            }
            if (propNameID != null && obj.GetType().GetProperty(propNameID) != null && this.CurrentUser != null)
            {
                obj.GetType().GetProperty(propNameID,
                    BindingFlags.Instance | BindingFlags.Public | BindingFlags.Instance).SetValue(obj, this.CurrentUser.ID, null);
            }
        }
    }
}
