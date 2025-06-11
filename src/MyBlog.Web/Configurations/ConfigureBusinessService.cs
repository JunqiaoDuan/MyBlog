using MyBlog.Infrastructure.ExternalInterface;
using MyBlog.Service.Services.Profiles;
using MyBlog.Service.Services.Projects;
using MyBlog.Service.Services.Statistics;
using MyBlog.Service.Shared.Interfaces.ExternalInterface;
using MyBlog.Service.Shared.Interfaces.Profiles;
using MyBlog.Service.Shared.Interfaces.Projects;
using MyBlog.Service.Shared.Interfaces.Statistics;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureBusinessService
    {
        public static WebApplicationBuilder AddBusinessService(this WebApplicationBuilder builder)
        {
            // todo: inject services automatically
            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IStatisticService, StatisticService>();
            builder.Services.AddScoped<IYearlyHeatMapService, YearlyHeatMapService>();

            return builder;
        }
    }
}
