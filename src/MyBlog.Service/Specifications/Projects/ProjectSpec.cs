using Ardalis.Specification;
using MyBlog.Service.Entities.ProjectAgregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Specifications.Projects
{
    public class ProjectSpec : Specification<Project>
    {
        public ProjectSpec()
        {
            Query.Where(p =>
                p.IsValid == true);
        }
    }
}
