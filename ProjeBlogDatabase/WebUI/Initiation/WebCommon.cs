using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Initiation
{
    public class WebCommon : ICommon
    {
        public string GetUserName()
        {
            if (HttpContext.Current.Session["Login"] !=null)
            {
                User user = HttpContext.Current.Session["Login"] as User;
                return user.User_Name;
            }
            return null;
        }
    }
}