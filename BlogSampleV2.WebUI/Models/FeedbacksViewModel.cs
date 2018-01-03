using BlogSampleV2.Domain.Enteties;
using System.Collections.Generic;

namespace BlogSampleV2.WebUI.Models
{
    public class FeedbacksViewModel : PostsViewModel
    {
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }
}