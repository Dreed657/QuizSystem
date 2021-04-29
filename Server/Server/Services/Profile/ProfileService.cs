using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.ExamAttempt;
using Server.Models.Profile;

namespace Server.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly ApplicationDbContext _db;

        public ProfileService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ProfileViewModel> GetProfile(string id)
        {
            return await this._db.Users
                .Where(x => x.Id == id)
                .Select(x => new ProfileViewModel()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Exams = x.Exams.Select(y => new ExamAttemptViewModel()
                    {
                        Id = y.Id,
                        UserId = y.UserId,
                        ExamName = y.Exam.Name,
                        StartTime = y.StartTime,
                        EndTime = y.EndTime,
                        Score = y.Score,
                        CorrectAnswers = y.CorrectAnswers,
                        WrongAnswers = y.WrongAnswers
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}