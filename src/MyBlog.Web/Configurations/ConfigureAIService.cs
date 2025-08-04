using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using MyBlog.ExternalService.AI;
using MyBlog.ExternalService.AI.Google;
using MyBlog.ExternalService.AI.OpenAI;
using MyBlog.Infrastructure.ExternalInterface;
using MyBlog.Service.Services.Profiles;
using MyBlog.Service.Services.Projects;
using MyBlog.Service.Services.Statistics;
using MyBlog.Service.Shared.Interfaces.AI;
using MyBlog.Service.Shared.Interfaces.AI.Model;
using MyBlog.Service.Shared.Interfaces.ExternalInterface;
using MyBlog.Service.Shared.Interfaces.Profiles;
using MyBlog.Service.Shared.Interfaces.Projects;
using MyBlog.Service.Shared.Interfaces.Statistics;
using MyBlog.Web.Data;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureAIService
    {
        public static WebApplicationBuilder AddAIService(this WebApplicationBuilder builder, MyBlogSetting myBlogSetting)
        {
            var secretClient = new SecretClient(new Uri(myBlogSetting.Azure_KeyVault.Url), new DefaultAzureCredential());

            #region Open AI

            var openAIendpoint = secretClient.GetSecretAsync(myBlogSetting.Azure_KeyVault.Name_OpenAIEndpoint).Result.Value.Value;
            var openAISecretKey = secretClient.GetSecretAsync(myBlogSetting.Azure_KeyVault.Name_OpenAISecretKey).Result.Value.Value;

            builder.Services.AddSingleton<OpenAIService>(sp =>
                new OpenAIService(new AIServiceContext()
                {
                    EndPoint = openAIendpoint,
                    SecretKey = openAISecretKey
                })
            );

            #endregion

            #region Gemini

            builder.Services.AddSingleton<GeminiService>();

            #endregion

            // Register keyed services for IAIService
            builder.Services.AddKeyedSingleton<IAIService, OpenAIService>(AIConst.OpenAI, (sp, _) => sp.GetRequiredService<OpenAIService>());
            builder.Services.AddKeyedSingleton<IAIService, GeminiService>(AIConst.Gemini, (sp, _) => sp.GetRequiredService<GeminiService>());

            // Register the AIServiceFactory
            builder.Services.AddSingleton<IAIServiceFactory, AIServiceFactory>();

            return builder;
        }
    }
}
