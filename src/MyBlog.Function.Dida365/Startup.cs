using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Infrastructure.ExternalInterface;
using MyBlog.Service.Services.Statistics;
using MyBlog.Service.Shared.Interfaces.ExternalInterface;
using MyBlog.Service.Shared.Interfaces.Statistics;
using MyBlog.Service.Shared.Repository;
using System;

[assembly: FunctionsStartup(typeof(MyBlog.Function.Dida365.Startup))]
namespace MyBlog.Function.Dida365
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            #region fetch setting

            var connectionString = Environment.GetEnvironmentVariable("ConnectionString");

            #endregion

            #region inject context

            builder.Services.AddDbContext<DbContext, MyBlogContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            #endregion

            #region Register repositories

            builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));
            builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EFRepository<>));

            #endregion

            #region Register business services

            builder.Services.AddTransient<IStatisticService, StatisticService>();
            builder.Services.AddTransient<IYearlyHeatMapService, YearlyHeatMapService>();

            #endregion
        }
    }
}