using Microsoft.AspNetCore.Hosting;
using Microsoft.JSInterop;
using Microsoft.Playwright;
using MyBlog.External.PDFGenerator.Const;
using MyBlog.External.PDFGenerator.Template.MyCV.Model;
using static MudBlazor.CategoryTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyBlog.Web.Pages
{
    public partial class Resume
    {
        protected override async Task OnInitializedAsync()
        {
            await generatePdf();
        }

        private async Task generatePdf()
        {
            #region Profile

            var dbProfiles = await _profileService.GetProfilesAsync();

            var avatarPath = dbProfiles.FirstOrDefault(p => p.Name == "Avatar")?.Value;

            var profileView = new MyCVPdfModel()
            {
                Name = dbProfiles.FirstOrDefault(p => p.Name == "Name")?.Value,
                Avatar = avatarPath == null? null : await File.ReadAllBytesAsync(avatarPath),

                GitHub = dbProfiles.FirstOrDefault(p => p.Name == "GitHub")?.Value,
                Discord = dbProfiles.FirstOrDefault(p => p.Name == "Discord")?.Value,
                Email = dbProfiles.FirstOrDefault(p => p.Name == "Email")?.Value,
                Bio = dbProfiles.FirstOrDefault(p => p.Name == "Bio")?.Value,
                Skills = dbProfiles.FirstOrDefault(p => p.Name == "Skills")?.Value,
            };

            #endregion

            #region Projects

            var dbProjects = await _projectService.GetProjectsAsync();

            profileView.DataList_Project = dbProjects
                .OrderBy(p => p.SortNo)
                .Select(p => new MyCVPdfModel_Project()
                {
                    Name = p.Name,
                    Description = p.Description,
                    Image = string.IsNullOrWhiteSpace(p.ImageUrl) ? null : File.ReadAllBytes(p.ImageUrl),
                    UrlGitHub = p.UrlGitHub,
                })
                .ToList();

            #endregion

            #region File Path

            var basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "AllowedDownload");
            var subPath = $"MyCV-{DateTime.Now.ToString("yyyyMMdd")}-{Guid.NewGuid()}";
            var fileName = "MyCV.pdf";

            if (!Directory.Exists(Path.Combine(basePath, subPath)))
            {
                Directory.CreateDirectory(Path.Combine(basePath, subPath));
            }

            var fileFullPath = Path.Combine(
                basePath,
                subPath,
                fileName
                );

            #endregion

            #region Generate File

            await _pdfService.GenerateAndSavePdfAsync(
                PDFTemplateConst.TemplateName_MyCV,
                profileView,
                fileFullPath
                );

            #endregion

        }

    }
}
