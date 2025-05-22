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
using MyBlog.Web.Data;
using System.Threading.Tasks;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureAzureService
    {
        public static WebApplicationBuilder AddAzureServices(this WebApplicationBuilder builder, MyBlogSetting myBlogSetting)
        {
            var secretClient = new SecretClient(new Uri(myBlogSetting.Azure_KeyVault.Url), new DefaultAzureCredential());

            var blogConnection = secretClient.GetSecretAsync(myBlogSetting.Azure_KeyVault.Name_BlogConn).Result.Value.Value;
            var queueConnection = secretClient.GetSecretAsync(myBlogSetting.Azure_KeyVault.Name_QueueConn).Result.Value.Value;

            builder.Services.AddAzureClients(azureBuilder =>
            {
                azureBuilder.AddBlobServiceClient(blogConnection);

                azureBuilder.AddQueueServiceClient(queueConnection)
                    .ConfigureOptions(options =>
                    {
                        options.MessageEncoding = QueueMessageEncoding.Base64;
                    });
            });

            return builder;
        }
    }
}
