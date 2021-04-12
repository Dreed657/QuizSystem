namespace Server.Services.Common
{
    public interface ICurrentUserService
    {
        string GetUserName();

        string GetId();
    }
}
