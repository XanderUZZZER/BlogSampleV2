using BlogSampleV2.Domain.Entities;
using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.WebUI.Areas.Administration.Models;
using BlogSampleV2.WebUI.Filters;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSampleV2.WebUI.Areas.Administration.Controllers
{    
    public class AdminController : Controller
    {
        private IBlogRepository repository;
        private BlogUser user;

        public AdminController(IBlogRepository repository)
        {
            this.repository = repository;
        }
        // GET: Administration/Administration 
        //[BlogAuthorize(Roles = "ContentManager")]       
        public ViewResult Index()
        {
            return View(user);
        }

        [AllowAnonymous]
        public ViewResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                user = repository.Users.Where(u => ((u.Nick == model.UserName) && (u.Password == model.Password))).FirstOrDefault();
                var tt = repository.Users.Where(u => (u.Nick == model.UserName) && (u.Password == model.Password));
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                if ((user != null)&& (user.Role.Name == "ContentManager"))
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}