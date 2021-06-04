using System.Collections.Generic;
using System.Threading.Tasks;
using Server.Models.User;

namespace Server.Services.NewFolder
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAll();

        Task<UserViewModel> GetById(string id);
    }
}
