using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
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
            // todo
            var keyVaultUrl = "https://keyvaultmyblogdev001.vault.azure.net/";
            var sqlConnName = "ConnectionStrings-MyBlog-SqlDb";

            var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            var sqlConnection = secretClient.GetSecretAsync(sqlConnName).Result.Value.Value;

            #region Service Repository

            services.AddDbContext<DbContext, MyBlogContext>((serviceProvider, options) =>
            {
                options.UseSqlServer(sqlConnection);
            });

            services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));

            #endregion

            return services;
        }
    }
}
