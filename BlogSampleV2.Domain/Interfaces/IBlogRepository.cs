using BlogSampleV2.Domain.Entities;
using System.Collections.Generic;

namespace BlogSampleV2.Domain.Interfaces
{
    public interface IBlogRepository
    {
        IEnumerable<BlogUser> Users { get; }
        IEnumerable<Article> Articles { get; }
        IEnumerable<Feedback> Feedbacks { get; }
        IEnumerable<Tag> Tags { get; }
        IEnumerable<Skill> Skills { get; }
        void AddUser(BlogUser user);
        void AddArticle(Article article);
        void AddFeedback(string fName, string lName, string feedback);
        void ArticleAddTags(Article article, List<int> tagIds);
    }
}
