using MyBlog.Service.Entities.Common;
using MyBlog.Service.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Entities.ProjectAgregate
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UrlGitHub { get; set; }
        public string UrlDemo { get; set; }
        public int SortNo { get;set; }
    }
}
