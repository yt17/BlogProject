using BusinessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace WebUI.Models
{
    public class CacheHelper
    {
        public static List<Category> GetCategories()
        {
            var result =WebCache.Get("category-cache");
            if (result==null)
            {
                CategoryManager cm = new CategoryManager();
                result = cm.List();
                WebCache.Set("category-cache", result, 20, true);
            }
            return result;
        }
    }
}