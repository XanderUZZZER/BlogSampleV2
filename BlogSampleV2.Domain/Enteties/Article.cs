using System.Collections.Generic;

namespace BlogSampleV2.Domain.Enteties
{
    public class Article : Post
    {
        public string Title { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}
