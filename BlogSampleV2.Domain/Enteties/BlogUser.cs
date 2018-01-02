using System;
using System.Collections;
using System.Collections.Generic;

namespace BlogSampleV2.Domain.Enteties
{
    public class BlogUser : Person
    {
        public string Nick { get; set; }
        public DateTime RegDate { get; set; }
        public ICollection<Article> Articles { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
