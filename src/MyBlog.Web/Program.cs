using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MyBlog.Web.Configurations;
using MyBlog.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

#region Custom Register

builder.AddMyBlogSetting(out MyBlogSetting myBlogSetting);

builder.AddRepositories(myBlogSetting);
builder.AddBusinessService();
builder.AddAzureServices(myBlogSetting);

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
