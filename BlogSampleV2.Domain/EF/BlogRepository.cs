using System;
using System.Collections.Generic;
using BlogSampleV2.Domain.Enteties;
using BlogSampleV2.Domain.Interfaces;
using System.Web;
using System.Linq;

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

        public IEnumerable<Article> Articles
        {
            get
            {
                return blogContext.Articles;
            }
        }

        public IEnumerable<Feedback> Feedbacks
        {
            get
            {
                return blogContext.Feedbacks;
            }
        }

        public IEnumerable<Tag> Tags
        {
            get
            {
                return blogContext.Tags;
            }
        }

        public IEnumerable<Skill> Skills
        {
            get
            {
                return blogContext.Skills;
            }
        }

        public void AddUser(BlogUser user)
        {
            BlogUser dbEntry = blogContext.Users.Where(u => (u.FirstName == user.FirstName) && (u.LastName == user.LastName)).FirstOrDefault();
            if (dbEntry != null)
            {
                dbEntry.Gender = user.Gender;
                dbEntry.Nick = user.Nick;
                dbEntry.Skills.Clear();
                dbEntry.Skills = user.Skills;
            }
            else
            {
                user.RegDate = DateTime.Now;
                blogContext.Users.Add(user);
            }            
            blogContext.SaveChanges();
        }
    }
}
