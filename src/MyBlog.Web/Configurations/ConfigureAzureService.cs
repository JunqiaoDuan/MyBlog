using Azure.Core.Extensions;
using Azure.Storage.Queues;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Options;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Service.Shared.Repository;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureAzureService
    {
        public static IServiceCollection AddAzureServices(
            this IServiceCollection services,
            WebApplicationBuilder builder)
        {

            var storageConnection = builder.Configuration["ConnectionStrings:MyBlog:Storage"];
            var queueConnection = builder.Configuration["ConnectionStrings:MyBlog:Queue"];

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
