using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Service.Shared.Repository;
using MyBlog.Web.Data;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureRepository
    {
        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder, MyBlogSetting setting)
        {
            var secretClient = new SecretClient(new Uri(setting.Azure_KeyVault.Url), new DefaultAzureCredential());

            var sqlConnection = secretClient.GetSecretAsync(setting.Azure_KeyVault.Name_SqlServerConn).Result.Value.Value;

            #region Service Repository

            builder.Services.AddDbContext<DbContext, MyBlogContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(sqlConnection);
            });

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));

            #endregion

            return builder;
        }
    }
}
