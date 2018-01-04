using BlogSampleV2.Domain.Enteties;
using System.Collections.Generic;

namespace BlogSampleV2.WebUI.Models
{
    public class QuestionnaireViewModel
    {
        public BlogUser User { get; set; }
        public IEnumerable<Skill> Skills { get; set; }
    }
}