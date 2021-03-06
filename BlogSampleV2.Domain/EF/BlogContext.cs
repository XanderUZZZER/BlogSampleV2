﻿using BlogSampleV2.Domain.Enteties;
using System.Data.Entity;

namespace BlogSampleV2.Domain.EF
{
    class BlogContext : DbContext
    {
        public DbSet<BlogUser> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Tag> Tags { get; set; }
        
        public BlogContext(string connectionString) : base (nameOrConnectionString: connectionString)
        {
        }
    }
}
