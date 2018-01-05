using System;

namespace BlogSampleV2.Domain.Entities
{
    public abstract class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }

        public int AuthorId { get; set; }
        public virtual BlogUser Author { get; set; }
    }
}
