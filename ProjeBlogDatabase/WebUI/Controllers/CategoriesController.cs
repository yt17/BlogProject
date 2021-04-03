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
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    
    public class CategoriesController : Controller
    {
        CategoryManager CM = new CategoryManager();
        ErrorViewModel ok = new ErrorViewModel();
        // GET: Categories



        [AllowAnonymous]        
        public ActionResult Index()
        {
            return View(CM.List());
        }


        [Auth]
        public ActionResult Create()
        {
            return View();
        }
        [Auth]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.Active = false;
                CM.Insert(category);                
                return RedirectToAction("Index");
            }

            return View(category);
        }


        //tamamlandi
        [AutAdmin]
        public ActionResult CategoryList()
        {
            return View(CM.List());
        }


        //tamamlandi
        [AutAdmin]
        public string  FEdit(int id,string deger1,bool deger2)
        { 
                Category c = new Category();
                c= CM.Find(x => x.ID==id);
                c.Category_Name = deger1;
                c.Active = deger2;
                CM.Update(c);
            return "tamam";
           
        }

        //tamamlandi
        [AutAdmin]
        public void Delete(int? id)
        {            
            Category category =CM.Find(x=>x.ID==id);            
            CM.Delete(category);
            
        }




        [AutAdmin]
        public PartialViewResult LoadData(int? id) {
            Category zx = CM.Find(x => x.ID == id);
            return PartialView("ModalSmall", zx);
        }



    }
}
