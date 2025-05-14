using MyBlog.Service.Entities.ProjectAgregate;
using MyBlog.Service.Shared.Dtos.Queries;
using MyBlog.Service.Shared.Interfaces.Projects;
using MyBlog.Service.Shared.Repository;
using MyBlog.Service.Specifications.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Projects
{
    public class ProjectService : IProjectService
    {

        #region fields

        private readonly IRepository<Project> _projectRepository;

        #endregion

        #region constructor

        public ProjectService(IRepository<Project> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        #endregion

        #region public methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IList<ProjectQueryView>> GetProjectsAsync()
        {
            var spec = new ProjectSpec();
            var projects = await _projectRepository.ListAsync(spec);

            // todo
            var views = projects.Select(p => new ProjectQueryView()
            {
                Name = p.Name,
                Description = p.Description,
                UrlGitHub = p.UrlGitHub,
                UrlDemo = p.UrlDemo
            }).ToList();

            return views;
        }

        #endregion

    }
}
