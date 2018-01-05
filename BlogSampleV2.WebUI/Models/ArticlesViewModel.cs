using BlogSampleV2.Domain.Entities;
using System.Collections.Generic;

namespace BlogSampleV2.WebUI.Models
{
    public class ArticlesViewModel : PostsViewModel
    {
        public IEnumerable<Article> Articles { get; set; }
    }
}