using MyBlog.Service.Entities.Common;
using MyBlog.Service.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Entities.StatisticAggregate
{
    public class Statistic : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
