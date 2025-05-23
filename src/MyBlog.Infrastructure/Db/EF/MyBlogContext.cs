using Microsoft.EntityFrameworkCore;
using MyBlog.Service.Entities.ProjectAgregate;
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
        }

    }
}
