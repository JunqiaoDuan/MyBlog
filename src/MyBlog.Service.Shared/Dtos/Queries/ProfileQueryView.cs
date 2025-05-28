using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Dtos.Queries
{
    public class ProfileQueryView
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int SortNo { get; set; }
    }
}
