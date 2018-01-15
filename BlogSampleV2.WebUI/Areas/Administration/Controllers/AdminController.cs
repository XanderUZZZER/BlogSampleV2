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

        public string Login()
        {
            return "Log in here";
        }
    }
}