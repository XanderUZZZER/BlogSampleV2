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
            ArticleViewModel model = new ArticleViewModel();
            foreach (var tag in repository.Tags)
            {
                model.AvailableTags.Add(new SelectListItem
                {
                    Value = tag.Id.ToString(), Text = tag.TagName
                });
            }
            return View(model);
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
            List<int> Ids = new List<int>();
            foreach (var tag in model.SelectesTags)
            {
                Ids.Add(Convert.ToInt32(tag));
            }
            repository.ArticleAddTags(article, Ids);
            return Redirect("~/Home");
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