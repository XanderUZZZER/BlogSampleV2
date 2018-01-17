using BlogSampleV2.Domain.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BlogSampleV2.WebUI.Areas.Administration.Models
{
    public class ArticleViewModel
    {
        [Required]
        [Display(Name = "Article title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Article content")]
        public string Text { get; set; }

        public List<SelectListItem> AvailableTags { get; set; } = new List<SelectListItem>();
        public List<string> SelectesTags { get; set; } = new List<string>();
    }
}