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
using WebUI.Requires;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    //[Auth]
    public class ArticlesController : Controller
    {
        ArticleManager Arm = new ArticleManager();
        ErrorViewModel EM = new ErrorViewModel();
        CategoryManager cm = new CategoryManager();
        Article art = new Article();

        // GET: Articles
        public ActionResult Index()
        {
            return View(Arm.List());
        }

        // GET: Articles/Details/5

        
        public PartialViewResult Loaddata(int? id)
        {
            Article zzz = new Article();
            zzz = Arm.Find(x => x.ID == id);
            return PartialView("ModalLarge",zzz);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.lste = cm.List();
            return View();
        }

        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
       

        // GET: Articles/Edit/5



        public string Edit(int? id,string vtitle,string vltitle,string vtext)
        {
            //id: id, vtitle: vtitle, vltitle: vltitle, vtext: vtext 
            art = Arm.Find(x => x.ID == id);
            art.Article_Name = vtitle;
            art.Article_Litle = vltitle;
            art.Article_Text = vtext;
            Arm.Update(art);
            return "tamam";
        }

      
    }
}
