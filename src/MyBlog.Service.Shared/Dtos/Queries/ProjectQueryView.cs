using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Dtos.Queries
{
    public class ProjectQueryView
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string UrlGitHub { get; set; }
        public string UrlDemo { get; set; }
        public int SortNo { get; set; }
    }
}
