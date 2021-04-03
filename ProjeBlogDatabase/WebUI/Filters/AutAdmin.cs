using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Requires;

namespace WebUI.Filters
{
    public class AutAdmin : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (SessionManagement.User==null)
            {
                filterContext.Result = new RedirectResult("/Home/Index");
            }
            else
            {
                if (SessionManagement.User.Admin == false)
                {
                    filterContext.Result = new RedirectResult("/Home/Index");
                }
            }
            
            
        }
    }
}