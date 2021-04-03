using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Requires;

namespace WebUI.Filters
{
    public class Auth : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionManagement.User==null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
        }
    }
}