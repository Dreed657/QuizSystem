using System.Threading.Tasks;
using Server.Models.Profile;

namespace Server.Services.Profile
{
    public interface IProfileService
    {
        Task<ProfileViewModel> GetProfile(string id);
    }
}
