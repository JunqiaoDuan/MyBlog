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
using System.Net;
using System.Net.Http;
using Microsoft.Playwright;

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

        public async Task<List<DateIntValue>> ReadFromDbAsync()
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

        public async Task ScrapeAndSaveToDbAsync()
        {

            var userCredential = await getUserCredentialAsync();
            await saveHeatMapDataAsync();

        }

        #endregion

        #region Save Heat Map

        private async Task<string> getUserCredentialAsync()
        {
            var retDic = new Dictionary<string, string>();

            // Install Playwright browsers (only needed once)
            // Run this command manually first: 
            // powershell -ExecutionPolicy Bypass -File playwright.ps1 install

            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new()
            {
                Headless = true, // Set to false for debugging
                Timeout = 60000
            });

            var page = await browser.NewPageAsync();

            try
            {
                // Step 1: Navigate to login page
                await page.GotoAsync("https://dida365.com/signin", new()
                {
                    WaitUntil = WaitUntilState.NetworkIdle,
                    Timeout = 9000
                });

                // Step 2: Fill credentials
                var username = "djq321@126.com";
                var password = "MOSIV20dd";
                await page.FillAsync("input[id='emailOrPhone']", username);
                await page.FillAsync("input[id='password']", password);

                // Step 3: Click login button
                await page.ClickAsync("button:has-text('登录')");

                // Wait for navigation to complete
                await page.WaitForURLAsync(url => url.Contains("webapp"), new()
                {
                    Timeout = 9000
                });

                // Step 4: Get cookies
                var browserCookies = await page.Context.CookiesAsync();

                // Step 5: Get Data from api


                // Example usage inside getUserCredentialAsync or another method:
                var year = DateTime.Now.Year;
                var startDate = DateTime.Now.AddYears(-1).AddDays(1).ToString("yyyyMMdd");
                var endDate = DateTime.Now.ToString("yyyyMMdd");
                var heatmapUrl = $"https://api.dida365.com/api/v2/pomodoros/statistics/heatmap/{startDate}/{endDate}";

                var cookies = browserCookies
                    .GroupBy(c => c.Name)
                    .Select(g => g.First())
                    .ToDictionary(c => c.Name, c => c.Value);
                // No changes needed for the selected line as it does not repeat within the current method or file context.
                var heatmapJson = await FetchHeatMapDataAsync(cookies, heatmapUrl);



                return heatmapJson;
            }
            catch (Exception e)
            {
                Console.Write(e.Message);
            }
            finally
            {
                await browser.CloseAsync();

            }
            return "";

        }

        private async Task<string> FetchHeatMapDataAsync(Dictionary<string, string> cookies, string heatmapUrl)
        {
            using var handler = new HttpClientHandler();
            using var client = new HttpClient(handler);

            // Build cookie header
            var cookieHeader = string.Join("; ", cookies.Select(kvp => $"{kvp.Key}={kvp.Value}"));
            var request = new HttpRequestMessage(HttpMethod.Get, heatmapUrl);
            request.Headers.Add("Cookie", cookieHeader);
            request.Headers.Add("User-Agent", "Mozilla/5.0 (compatible; YearlyHeatMapService/1.0)");

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private async Task saveHeatMapDataAsync()
        {
            // Step 3: Fetch HeatMap data from the API using the authenticated session

            // Cookies are handled by handler.CookieContainer

            //var heatmapResponse = await client.SendAsync(heatmapRequest);
            //heatmapResponse.EnsureSuccessStatusCode();

            //var heatmapJson = await heatmapResponse.Content.ReadAsStringAsync();

            // TODO: Save heatmapJson to your statistics service or database as needed
            // Example:
            // await _statisticService.SaveStatisticAsync("pomodoro-history", heatmapJson);
        }

        #endregion

    }
}
