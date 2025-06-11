using MyBlog.Service.Entities.StatisticAggregate;
using MyBlog.Service.Shared.Dtos.ExternalDto.Dida365;
using MyBlog.Service.Shared.Dtos.VisualDto;
using MyBlog.Service.Shared.Interfaces.ExternalInterface;
using MyBlog.Service.Shared.Interfaces.Statistics;
using MyBlog.Service.Shared.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyBlog.Infrastructure.ExternalInterface
{
    public class YearlyHeatMapService : IYearlyHeatMapService
    {
        #region fields

        private readonly IStatisticService _statisticService;

        #endregion

        #region constructor

        public YearlyHeatMapService(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        #endregion

        #region public

        public async Task<List<DateIntValue>> GetHeatMapDataAsync()
        {
            var retViews = new List<DateIntValue>();

            var pomodoroJsons = await _statisticService.GetStatisticAsync("pomodoro-history");
            var pomodoroJson = pomodoroJsons.FirstOrDefault();

            if (string.IsNullOrWhiteSpace(pomodoroJson?.Value))
            {
                return retViews;
            }

            var pomodoroViews = JsonSerializer.Deserialize<List<Dida365PomodoroHistoryDto>>(
                pomodoroJson.Value,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (pomodoroViews == null)
            {
                return retViews;
            }

            var yearlyWorks = pomodoroViews
               .Select(i => new DateIntValue()
               {
                   Date = i.Day,
                   // pomodoro ratio: 10-min break every hour
                   Value = (int)((double)i.Duration * 6 / 5),
               })
               .ToList();

            return yearlyWorks;
        }

        public async Task SaveHeatMapAsync()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
