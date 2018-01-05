using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IBlogRepository repository;
        public int PageSize = 6;

        public HomeController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        // GET: All articles
        public ViewResult Articles(int page = 1)
        {
            ArticlesViewModel model = new ArticlesViewModel
            {
                Articles = repository.Articles
                                     .OrderBy(art => art.PostedDate)
                                     .Skip((page - 1) * PageSize)
                                     .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Articles.Count()
                }
            };
            return View(model);
        }

        public ViewResult Article(int id)
        {
            ArticleViewModel model = new ArticleViewModel
            {
                Article = repository.Articles.Where(art => art.Id == id).FirstOrDefault()
            };
            return View(model);
        }
    }
}