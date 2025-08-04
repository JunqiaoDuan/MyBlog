using MyBlog.Service.Shared.Dtos.Queries;

namespace MyBlog.Web.Pages
{
    public partial class Projects
    {
        private IEnumerable<ProjectQueryView>? projects;

        protected override async Task OnInitializedAsync()
        {
            projects = await _projectService.GetProjectsAsync();
        }
    }
}
