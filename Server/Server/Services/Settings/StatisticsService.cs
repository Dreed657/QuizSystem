using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.Statistics;

namespace Server.Services.Settings
{
    public class StatisticsService : IStatisticsService
    {
        private readonly ApplicationDbContext _db;

        public StatisticsService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<BaseStatsViewModel> GetBaseStats()
        {
            var examsCount = await this._db.Exams.CountAsync();
            var questionsCount = await this._db.Questions.CountAsync();
            var examAttemptsCount = await this._db.ExamParticipants.CountAsync();
            var usersCount = await this._db.Users.CountAsync();

            return new BaseStatsViewModel()
            {
                ExamAttemptsCount = examAttemptsCount,
                ExamsCount = examsCount,
                UsersCount = usersCount,
                QuestionsCount = questionsCount
            };
        }

        public async Task<IEnumerable<TopExamsStatsViewModel>> GetTopExamsByAttempts(int count)
        {
            return await this._db.Exams
                .OrderBy(x => x.Participants.Count())
                .Take(count)
                .Select(x => new TopExamsStatsViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    AttemptsCount = x.Participants.Count(),
                })
                .ToListAsync();
        }
    }
}