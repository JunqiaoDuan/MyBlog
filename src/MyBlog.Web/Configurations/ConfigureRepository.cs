using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Service.Shared.Repository;
using MyBlog.Web.Data;
using System;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureRepository
    {
        public static WebApplicationBuilder AddRepositories(this WebApplicationBuilder builder, MyBlogSetting setting)
        {
            InjectContext(builder, setting);
            InjectRepository(builder, setting);

            return builder;
        }

        #region inject context

        public static void InjectContext(WebApplicationBuilder builder, MyBlogSetting setting)
        {
            if (IsSqlite(setting))
            {
                InjectContext_Sqlite(builder, setting);
            }

            InjectContext_Default(builder, setting);
        }

        public static bool IsSqlite(MyBlogSetting setting)
        {
            return setting.DataBase.DatabaseSource == "sqlite";
        }

        public static void InjectContext_Default(WebApplicationBuilder builder, MyBlogSetting setting)
        {
            var secretClient = new SecretClient(new Uri(setting.Azure_KeyVault.Url), new DefaultAzureCredential());

            var sqlConnection = secretClient.GetSecretAsync(setting.Azure_KeyVault.Name_SqlServerConn).Result.Value.Value;

            #region Service Repository

            builder.Services.AddDbContext<DbContext, MyBlogContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(sqlConnection);
            });

            #endregion
        }

        public static void InjectContext_Sqlite(WebApplicationBuilder builder, MyBlogSetting setting)
        {
            var sqlConnection = setting.DataBase.DatabaseSource;

            #region Service Repository

            builder.Services.AddDbContext<DbContext, MyBlogContext>((serviceProvider, options) =>
            {
                options.UseSqlite(sqlConnection);
            });

            #endregion
        }

        #endregion

        #region reject repository

        public static void InjectRepository(WebApplicationBuilder builder, MyBlogSetting setting)
        {

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));

        }

        #endregion

    }
}
