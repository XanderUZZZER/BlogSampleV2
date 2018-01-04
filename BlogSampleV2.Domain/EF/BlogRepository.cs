using System;
using System.Collections.Generic;
using BlogSampleV2.Domain.Enteties;
using BlogSampleV2.Domain.Interfaces;
using System.Web;

namespace BlogSampleV2.Domain.EF
{
    public class BlogRepository : IBlogRepository
    {
        private BlogContext blogContext;

        public BlogRepository()
        {
            string dbFilePath = HttpContext.Current.Server.MapPath("~/App_Data/BlogV2.mdf");
            blogContext = new BlogContext(string.Format(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={0};MultipleActiveResultSets=True;Integrated Security=True;User Instance=False", dbFilePath));
        }

        public IEnumerable<BlogUser> Users
        {
            get
            {
                return blogContext.Users;
            }
        }

        IEnumerable<Article> IBlogRepository.Articles
        {
            get
            {
                return blogContext.Articles;
            }
        }

        IEnumerable<Feedback> IBlogRepository.Feedbacks
        {
            get
            {
                return blogContext.Feedbacks;
            }
        }

        IEnumerable<Tag> IBlogRepository.Tags
        {
            get
            {
                return blogContext.Tags;
            }
        }

        IEnumerable<Skill> IBlogRepository.Skills
        {
            get
            {
                return blogContext.Skills;
            }
        }
    }
}
