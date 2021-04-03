using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Entities;
using WebUI.Filters;

namespace WebUI.Controllers
{
    [AutAdmin]
    public class YNTMController : Controller
    {
        UserManagerAdmin UMD = new UserManagerAdmin();
        User Us = new User();
        
        // GET: YNTM
        public ActionResult Index()
        {
            
            return View(UMD.List()) ;
        }

        // GET: YNTM/Details/5
        //User_Name: col1, U_Name: col2, U_Surname: col3, Mail_Adress: col4, Active: col5
        public void Edit(int id, string User_Name,string U_Name,string U_Surname,string Mail_Adress,bool Active)
        {
            User cnrtl = UMD.Find(x => x.ID == id);
            cnrtl.User_Name = User_Name.TrimStart().TrimEnd();
            cnrtl.U_Name = U_Name.TrimStart().TrimEnd();
            cnrtl.U_Surname = U_Surname.TrimStart().TrimEnd();
            cnrtl.Mail_Adress = Mail_Adress.TrimStart().TrimEnd();
            cnrtl.Active = Active;
            UMD.Update(cnrtl);
        }
        public void SendGuid(int id, string User_Name, string Mail_Adress)
        {
            UserManager um = new UserManager();
            um.SendGuid(id, Mail_Adress, User_Name);
        }



    }
}
