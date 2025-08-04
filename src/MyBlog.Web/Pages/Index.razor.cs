using MyBlog.Service.Shared.Dtos.VisualDto;

namespace MyBlog.Web.Pages
{
    public partial class Index
    {
        string? avatar;
        string? name;
        string? location;
        string? github;
        string? discord;
        string? email;
        string? bio;
        string? skills;
        List<List<string>> skillItems = new List<List<string>>();

        List<DateIntValue> yearlyWorks = new List<DateIntValue>();

        protected override async Task OnInitializedAsync()
        {
            #region profile

            var profileViews = await _profileService.GetProfilesAsync();

            avatar = profileViews.FirstOrDefault(p => p.Name == "Avatar")?.Value;
            name = profileViews.FirstOrDefault(p => p.Name == "Name")?.Value;
            location = profileViews.FirstOrDefault(p => p.Name == "Location")?.Value;
            github = profileViews.FirstOrDefault(p => p.Name == "GitHub")?.Value;
            discord = profileViews.FirstOrDefault(p => p.Name == "Discord")?.Value;
            email = profileViews.FirstOrDefault(p => p.Name == "Email")?.Value;
            bio = profileViews.FirstOrDefault(p => p.Name == "Bio")?.Value;
            skills = profileViews.FirstOrDefault(p => p.Name == "Skills")?.Value;

            if (!string.IsNullOrWhiteSpace(skills))
            {
                skillItems = skills
                    .Split(';', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                    .Select(g => g.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).ToList())
                    .ToList();
            }

            #endregion

            yearlyWorks = await _yearlyHeatMapService.ReadFromDbAsync();

            // todo 
            // var service = _aiServiceFactory.GetService(AIConst.OpenAI);
            // service.Test();

        }

    }
}
