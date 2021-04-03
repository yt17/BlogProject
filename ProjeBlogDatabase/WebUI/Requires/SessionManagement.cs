using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Requires
{
    public static class SessionManagement
    {
        public static User User
        {
            get
            {
                return Get<User>("Login");
            }
        }
        public static string G_UserName()
        {
            return Get<User>("Login").User_Name;
        }
        public static void Set<T>(string Key,T obj)
        {
            HttpContext.Current.Session[Key] = obj;
        }
        public static T Get<T>(string Key) {
            if (HttpContext.Current.Session[Key]!=null)
            {
                return (T)HttpContext.Current.Session[Key];
            }
            return default(T);
        }
        public static void Remove(string Key)
        {
            if (HttpContext.Current.Session[Key]!=null)
            {
                HttpContext.Current.Session.Remove(Key);
            }
        }
        public static void clear() {
            HttpContext.Current.Session.Clear();
        }

    }
}