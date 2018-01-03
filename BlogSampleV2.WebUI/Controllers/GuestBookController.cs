using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.WebUI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Controllers
{
    public class GuestBookController : Controller
    {
        private IBlogRepository repository;
        public int PageSize = 4;

        public GuestBookController(IBlogRepository repository)
        {
            this.repository = repository;
        }

        // GET: Article
        public ViewResult Feedbacks(int page = 1)
        {
            FeedbacksViewModel model = new FeedbacksViewModel
            {
                Feedbacks = repository.Feedbacks
                                      .OrderBy(art => art.PostedDate)
                                      .Skip((page - 1) * PageSize)
                                      .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Feedbacks.Count()
                }
            };

            return View(model);
        }
    }
}