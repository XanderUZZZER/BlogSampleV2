using System.ComponentModel.DataAnnotations;

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
    }
}