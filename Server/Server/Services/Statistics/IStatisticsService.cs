using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.Statistics;

namespace Server.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<BaseStatsViewModel> GetBaseStats();

        Task<IEnumerable<TopExamsStatsViewModel>> GetTopExamsByAttempts(int count);
    }
}
