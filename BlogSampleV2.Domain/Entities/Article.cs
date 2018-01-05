using System.Collections.Generic;

namespace BlogSampleV2.Domain.Entities
{
    public class Article : Post
    {
        public string Title { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }
    }
}
