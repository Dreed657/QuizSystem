using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Services.Settings;

namespace Server.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet(nameof(GetBaseStats))]
        public async Task<IActionResult> GetBaseStats()
        {
            var result = await this._statisticsService.GetBaseStats();

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet(nameof(GetTopExams))]
        public async Task<IActionResult> GetTopExams(int count)
        {
            var result = await this._statisticsService.GetTopExamsByAttempts(count);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
