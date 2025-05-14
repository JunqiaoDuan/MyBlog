using MyBlog.Service.Services.Projects;
using MyBlog.Service.Shared.Interfaces.Projects;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureBusinessService
    {
        public static IServiceCollection AddBusinessService(
            this IServiceCollection services)
        {

            services.AddScoped<IProjectService, ProjectService>();

            return services;
        }
    }
}
