using Azure.Core.Extensions;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Storage.Queues;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Service.Shared.Repository;
using System.Threading.Tasks;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureAzureService
    {
        public static IServiceCollection AddAzureServices(
            this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            // todo
            var keyVaultUrl = "https://keyvaultmyblogdev001.vault.azure.net/";
            var storageConnName = "ConnectionStrings-MyBlog-Storage";
            var queueConnName = "ConnectionStrings-MyBlog-Queue";

            var secretClient = new SecretClient(new Uri(keyVaultUrl), new DefaultAzureCredential());

            var storageConnection = secretClient.GetSecretAsync(storageConnName).Result.Value.Value;
            var queueConnection = secretClient.GetSecretAsync(queueConnName).Result.Value.Value;

            services.AddAzureClients(azureBuilder =>
            {
                azureBuilder.AddBlobServiceClient(storageConnection);

                azureBuilder.AddQueueServiceClient(queueConnection)
                    .ConfigureOptions(options =>
                    {
                        options.MessageEncoding = QueueMessageEncoding.Base64;
                    });
            });

            return services;
        }
    }
}
