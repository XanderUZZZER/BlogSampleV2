using BlogSampleV2.WebUI.Areas.Administration.Models;
using BlogSampleV2.WebUI.Filters;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Areas.Administration.Controllers
{    
    public class AdminController : Controller
    {
        // GET: Administration/Administration 
        [BlogAuthorize(Roles = "ContentManager")]       
        public ActionResult Index()
        {
            return View();
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
                return RedirectToAction("Index");
            return View();
        }
    }
}