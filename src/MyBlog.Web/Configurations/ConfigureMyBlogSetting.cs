using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MyBlog.Infrastructure.Db.EF;
using MyBlog.Service.Shared.Repository;
using MyBlog.Web.Data;

namespace MyBlog.Web.Configurations
{
    public static class ConfigureMyBlogSetting
    {
        public static WebApplicationBuilder AddMyBlogSetting(
            this WebApplicationBuilder builder,
            out MyBlogSetting myBlogSetting)
        {

            var section = builder.Configuration.GetSection(MyBlogSetting.MyBlogSettingSectionName);
            builder.Services.Configure<MyBlogSetting>(section);

            myBlogSetting = new MyBlogSetting();
            section.Bind(myBlogSetting);

            return builder;
        }
    }
}
