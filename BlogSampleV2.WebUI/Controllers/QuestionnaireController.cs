using BlogSampleV2.Domain.Entities;
using BlogSampleV2.Domain.Interfaces;
using BlogSampleV2.WebUI.Models;
using System.Collections.Generic;
using System.Linq;
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
        public ViewResult UpdateInfo()
        {
            QuestionnaireViewModel model = new QuestionnaireViewModel();
            model.Skills = repository.Skills;
            return View(model);
        }

        [AcceptVerbs("POST", "GET")]
        public ViewResult Result(QuestionnaireViewModel model, List<string> skills)
        {
            model.User.Skills = new List<Skill>();
            if(skills != null)
            {
                foreach (var s in skills)
                {
                    model.User.Skills.Add(repository.Skills.Where(sk => sk.Name == s).First());
                }
            }            
            repository.AddUser(model.User);
            return View(model);
        }
    }
}