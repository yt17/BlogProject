using BusinessLayer;
using BusinessLayer.Results;

using Entities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Requires;
using WebUI.ViewModels;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        UserManager UM = new UserManager();
        LayerResults<User> LR = new LayerResults<User>();
        ArticleManager ARM = new ArticleManager();
        // GET: Home
        public ActionResult Index()
        {
            List<Article> lste = ARM.List().Where(x=>x.Active=="T").OrderByDescending(e => e.ID).Take(5).ToList();

            return View(lste);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterVModel model)
        {           
            LR = UM.Register(model);
            if (LR.Errors.Count>0)
            {
                LR.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(model);
            }
            SessionManagement.Set<User>("Login", LR.Result);
            OkViewModel ok = new OkViewModel();
            ok.Header = "Başarılı";
            ok.Title = "Başarılı";
            ok.RootUrl = "/Home/Index";
            ok.Irouting = true;

            return View("Ok", ok);

            
        }
        public ActionResult test() {
            OkViewModel ok = new OkViewModel();
            ok.Header = "Başarılı";
            ok.Title = "Başarılı";
            ok.RootUrl = "/Home/Index";
            ok.Irouting = true;

            return View("Ok", ok);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginVModel model)
        {   
            LR=UM.Login(model);
            if (LR.Errors.Count>0)
            {
                LR.Errors.ForEach(x => ModelState.AddModelError("", x.Message));
                return View(model);
            }
            OkViewModel ok = new OkViewModel();
            ok.Header = "Başarılı";
            ok.Title = "Başarılı";
            ok.RootUrl = "/Home/Index";
            ok.Irouting = true;
            SessionManagement.Set<User>("Login", LR.Result);
            return View("Ok", ok);
            
        }
        public ActionResult Logout()
        {           
            SessionManagement.clear();
            return RedirectToAction("Index");
        }
        public ActionResult ActiveCode(Guid ID)
        {
            LR = UM.GuidCheck(ID);
            if (LR.Errors.Count>0)
            {
                TempData["errors"] = LR.Errors;
                return RedirectToAction("UserActiveOK");
            }
            else
            {
                OkViewModel ok = new OkViewModel();
                ok.Header = "Başarılı";
                ok.Title = "Başarılı";
                ok.RootUrl = "/Home/Index";
                ok.Irouting = true;
                return View("OK",ok);
            }
            return View();
        }
        public ActionResult UserActiveOK()
        {
            return View();
        }

    }
}