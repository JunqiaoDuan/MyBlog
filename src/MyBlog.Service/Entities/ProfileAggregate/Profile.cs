using MyBlog.Service.Entities.Common;
using MyBlog.Service.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Entities.ProfileAggregate
{
    public class Profile : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int SortNo { get; set; }
    }
}
