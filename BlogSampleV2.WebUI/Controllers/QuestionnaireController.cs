using BlogSampleV2.Domain.Interfaces;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Controllers
{
    public class QuestionnaireController : Controller
    {
        private IBlogRepository repository;

        public QuestionnaireController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        // GET: Questionnaire
        public ActionResult UpdateInfo()
        {
            return View();
        }
    }
}