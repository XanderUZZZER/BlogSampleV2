using BlogSampleV2.Domain.Interfaces;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private IBlogRepository repository;

        public BlogController()
        {
        }

        public BlogController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        // GET: Article
        public ViewResult Feed()
        {
            return View(repository.Articles);
        }
    }
}