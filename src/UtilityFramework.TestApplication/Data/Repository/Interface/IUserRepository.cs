using UtilityFramework.Data.Repository.Interface;

namespace UtilityFramework.TestApplication.Data.Repository.Interface
{
    public interface IUserRepository: IRepository
    {
        User Login(string login, string password);
    }
}