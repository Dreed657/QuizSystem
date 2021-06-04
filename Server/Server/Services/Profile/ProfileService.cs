using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Infrastructure.Mappings;
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
                .To<ProfileViewModel>()
                .FirstOrDefaultAsync();
        }
    }
}