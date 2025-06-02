using Ardalis.Specification;
using MyBlog.Service.Entities.ProfileAggregate;
using MyBlog.Service.Entities.ProjectAggregate;
using MyBlog.Service.Entities.StatisticAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Specifications.Statistics
{
    public class StatisticSpec : Specification<Statistic>
    {
        public StatisticSpec(string name)
        {
            Query.Where(i => i.IsValid == true && i.Name == name);
        }
    }
}
