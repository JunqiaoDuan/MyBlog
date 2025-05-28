using MyBlog.Service.Shared.Dtos.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.Profiles
{
    public interface IProfileService
    {
        public Task<IList<ProfileQueryView>> GetProfilesAsync();
    }
}
