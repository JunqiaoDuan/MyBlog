using MyBlog.Service.Shared.Dtos.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.Statistics
{
    public interface IStatisticService
    {
        public Task<IList<StatisticQueryView>> GetStatisticAsync(string name);
    }
}
