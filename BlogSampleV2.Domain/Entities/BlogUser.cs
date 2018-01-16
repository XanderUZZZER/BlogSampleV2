using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace BlogSampleV2.Domain.Entities
{
    public class BlogUser : Person
    {
        public string Nick { get; set; }
        public string Password { get; set; }
        public DateTime? RegDate { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Skill> Skills { get; set; }
    }
}
