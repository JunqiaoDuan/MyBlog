using Ardalis.Specification;
using MyBlog.Service.Entities.ProfileAggregate;
using MyBlog.Service.Entities.ProjectAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Specifications.Profiles
{
    public class ProfileSpec : Specification<Profile>
    {
        public ProfileSpec()
        {
            Query.Where(i => i.IsValid == true);
        }
    }
}
