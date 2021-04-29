using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models.User;
using Server.Services.NewFolder;

namespace Server.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _db;

        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            return await this._db.Users
                .Include(x => x.Exams)
                .Select(x => new UserViewModel()
                {
                    UserId = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    ExamsAttempted = x.Exams.Count()
                })
                .ToListAsync();
        }
    }
}