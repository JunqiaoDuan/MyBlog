using MyBlog.Service.Shared.Dtos.VisualDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Service.Shared.Interfaces.ExternalInterface
{
    public interface IYearlyHeatMapService
    {
        public Task<List<DateIntValue>> ReadFromDbAsync();
        public Task ScrapeAndSaveToDbAsync();
    }
}
