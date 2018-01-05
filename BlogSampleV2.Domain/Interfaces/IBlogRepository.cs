using BlogSampleV2.Domain.Enteties;
using System.Collections.Generic;

namespace BlogSampleV2.Domain.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<BlogUser> Users { get; }
        IEnumerable<Article> Articles { get; }
        IEnumerable<Feedback> Feedbacks { get; }
        IEnumerable<Skill> Skills { get; }
        void AddUser(BlogUser user);
        void AddFeedback(string fName, string lName, string feedback);
    }
}
