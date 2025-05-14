using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Service.Shared.Repository;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureRepository
    {
        public static IServiceCollection AddRepositories(
            this IServiceCollection services,
            WebApplicationBuilder builder)
        {

            #region Service Repository

            services.AddDbContext<DbContext, MyBlogContext>((serviceProvider, options) =>
            {
                var sqlConnection = builder.Configuration["ConnectionStrings:MyBlog:SqlDb"];
                options.UseSqlServer(sqlConnection);
            });

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));

            #endregion

            return services;
        }
    }
}
