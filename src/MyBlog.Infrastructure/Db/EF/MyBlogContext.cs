using Microsoft.EntityFrameworkCore;
using MyBlog.Service.Entities.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.Db.EF
{
    public class MyBlogContext : DbContext
    {

        public MyBlogContext()
        {
        }

        public MyBlogContext(DbContextOptions<MyBlogContext> options)
            : base(options)
        {
        }

        #region Tables

        public DbSet<Project> Project { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            initialiazeSeeds(builder);
        }

        private void initialiazeSeeds(ModelBuilder builder)
        {
            builder.Entity<Project>().HasData(
                new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test1",
                    Description = "Test2",
                    ImageUrl = "Test3",
                    UrlGitHub = "Test4",
                    UrlDemo = "Test5",
                    SortNo = 1,
                    IsValid = true,
                },
                new Project()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test1",
                    Description = "Test2",
                    ImageUrl = "Test3",
                    UrlGitHub = "Test4",
                    UrlDemo = "Test5",
                    SortNo = 1,
                    IsValid = true,
                });
            }

    }
}
