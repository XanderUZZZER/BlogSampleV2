using System;

namespace BlogSampleV2.Domain.Enteties
{
    public abstract class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PostedDate { get; set; }

        public int AuthorId { get; set; }
        public BlogUser Author { get; set; }
    }
}
