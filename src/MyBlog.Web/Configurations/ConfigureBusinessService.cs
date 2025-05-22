using MyBlog.Service.Services.Projects;
using MyBlog.Service.Shared.Interfaces.Projects;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureBusinessService
    {
        public static WebApplicationBuilder AddBusinessService(this WebApplicationBuilder builder)
        {
            // todo: inject services automatically
            builder.Services.AddScoped<IProjectService, ProjectService>();

            return builder;
        }
    }
}
