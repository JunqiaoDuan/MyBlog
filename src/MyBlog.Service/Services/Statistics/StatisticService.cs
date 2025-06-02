using MyBlog.Service.Entities.ProfileAggregate;
using MyBlog.Service.Entities.ProjectAggregate;
using MyBlog.Service.Entities.StatisticAggregate;
using MyBlog.Service.Shared.Dtos.Queries;
using MyBlog.Service.Shared.Interfaces.Profiles;
using MyBlog.Service.Shared.Interfaces.Statistics;
using MyBlog.Service.Shared.Repository;
using MyBlog.Service.Specifications.Profiles;
using MyBlog.Service.Specifications.Projects;
using MyBlog.Service.Specifications.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Services.Statistics
{
    public class StatisticService : IStatisticService
    {

        #region fields

        private readonly IRepository<Statistic> _statisticRepository;

        #endregion

        #region constructor

        public StatisticService(IRepository<Statistic> statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        #endregion

        public async Task<IList<StatisticQueryView>> GetStatisticAsync(string name)
        {
            var spec = new StatisticSpec(name);
            var statistics = await _statisticRepository.ListAsync(spec);

            // todo
            var views = statistics.Select(p => new StatisticQueryView()
            {
                Name = p.Name,
                Value = p.Value,
            }).ToList();

            return views;
        }
    }
}
