using BlogSampleV2.Domain.Entities;
using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.WebUI.Areas.Administration.Models;
using BlogSampleV2.WebUI.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BlogSampleV2.WebUI.Areas.Administration.Controllers
{    
    public class AdminController : Controller
    {
        private IBlogRepository repository;
        private static BlogUser user;

        public AdminController(IBlogRepository repository)
        {
            this.repository = repository;
        }
        // GET: Administration/Administration 
        //[BlogAuthorize(Roles = "ContentManager")]       
        public ViewResult AddArticle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddArticle(ArticleViewModel model)
        {
            Article article = new Article()
            {
                Title = model.Title,
                Text = model.Text,
                AuthorId = user.Id,
                PostedDate = DateTime.Now
            };
            repository.AddArticle(article);

            //return RedirectToRoute("Home");
            return Redirect("~/Home");            
            //return View("~/Views/Home/Articles.cshtml", repository.Articles);
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
                    return RedirectToAction("AddArticle");
                }
            }
            return View();
        }
    }
}