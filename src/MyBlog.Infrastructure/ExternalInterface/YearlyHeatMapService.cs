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
            // Step 1: Simulate login to https://dida365.com/signin using phone number and password
            // For demo, use placeholders. In production, use secure storage for credentials.
            var phone = "YOUR_PHONE_NUMBER";
            var password = "YOUR_PASSWORD";
            
            using var handler = new HttpClientHandler 
            { 
                UseCookies = true, 
                CookieContainer = new System.Net.CookieContainer() 
            };
            using var client = new HttpClient(handler);

            // Prepare login payload
            var loginPayload = new
            {
                username = phone,
                password = password
            };
            var loginContent = new StringContent(
                JsonSerializer.Serialize(loginPayload), 
                Encoding.UTF8, 
                "application/json"
            );

            // Step 2: Retrieve all cookies from the response of the API: https://api.dida365.com/api/v2/user/signon?wc=true&remember=true
            var loginResponse = await client.PostAsync("https://api.dida365.com/api/v2/user/signon?wc=true&remember=true", loginContent);
            loginResponse.EnsureSuccessStatusCode();

            // Cookies are now stored in handler.CookieContainer

            // Step 3: Fetch HeatMap data from the API: https://api.dida365.com/api/v2/pomodoros/statistics/heatmap/20250101/20251231
            //         Note: Use the cookies obtained above and recalculate the start and end dates for the year
            var year = DateTime.Now.Year;
            var startDate = new DateTime(year, 1, 1).ToString("yyyyMMdd");
            var endDate = new DateTime(year, 12, 31).ToString("yyyyMMdd");
            var heatmapUrl = $"https://api.dida365.com/api/v2/pomodoros/statistics/heatmap/{startDate}/{endDate}";

            var heatmapRequest = new HttpRequestMessage(HttpMethod.Get, heatmapUrl);
            // Attach cookies automatically via handler

            var heatmapResponse = await client.SendAsync(heatmapRequest);
            heatmapResponse.EnsureSuccessStatusCode();

            var heatmapJson = await heatmapResponse.Content.ReadAsStringAsync();

            // TODO: Save heatmapJson to your statistics service or database as needed
            // Example:
            // await _statisticService.SaveStatisticAsync("pomodoro-history", heatmapJson);
        }

        #endregion

        #region Save Heat Map



        #endregion

    }
}
