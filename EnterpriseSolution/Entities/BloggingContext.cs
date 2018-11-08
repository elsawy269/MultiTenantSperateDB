using EnterpriseSolution.Entities;
using EnterpriseSolution.Helper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace EnterpriseSolution.SQLite
{
    public class BloggingContext : DbContext
    {
        private readonly AppTenant _tenant;

        public DbSet<Post> Posts { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public BloggingContext(DbContextOptions<BloggingContext> options,
                                ITenantProvider tenantProvider)
            : base(options)
        {
            _tenant = tenantProvider.GetTenant();
          if(Database.EnsureCreated())
            {
                // seed data base 
            }


        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_tenant.DatabaseConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasKey(e => e.Id);
            modelBuilder.Entity<Blog>().HasKey(e => e.Id);
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Blog
    {
        //public DbSet<Post> Posts { get; set; }

        public int Id { get; set; }
        public string Url { get; set; }
        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}