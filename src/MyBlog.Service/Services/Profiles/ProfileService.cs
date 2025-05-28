using MyBlog.Service.Entities.ProfileAggregate;
using MyBlog.Service.Entities.ProjectAggregate;
using MyBlog.Service.Shared.Dtos.Queries;
using MyBlog.Service.Shared.Interfaces.Profiles;
using MyBlog.Service.Shared.Repository;
using MyBlog.Service.Specifications.Profiles;
using MyBlog.Service.Specifications.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Profiles
{
    public class ProfileService : IProfileService
    {

        #region fields

        private readonly IRepository<Profile> _porfileRepository;

        #endregion

        #region constructor

        public ProfileService(IRepository<Profile> profileRepository)
        {
            _porfileRepository = profileRepository;
        }

        #endregion

        public async Task<IList<ProfileQueryView>> GetProfilesAsync()
        {
            var spec = new ProfileSpec();
            var profiles = await _porfileRepository.ListAsync(spec);

            // todo
            var views = profiles.Select(p => new ProfileQueryView()
            {
                Name = p.Name,
                Value = p.Value,
                SortNo = p.SortNo,
            }).ToList();

            return views;
        }
    }
}
