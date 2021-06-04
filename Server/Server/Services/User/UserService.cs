using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Infrastructure.Mappings;
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
                .To<UserViewModel>()
                .ToListAsync();
        }

        public Task<UserViewModel> GetById(string id)
        {
            return this._db.Users
                .To<UserViewModel>()
                .SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}