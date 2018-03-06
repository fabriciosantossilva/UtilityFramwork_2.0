using MongoDB.Driver.Builders;
using UtilityFramework.TestApplication.Data.Repository.Interface;
using UtilityFramework.Data.Repository;

namespace UtilityFramework.TestApplication.Data.Repository
{
    public class UserRepository : UtilityFramework.Data.Repository.Repository, IUserRepository
    {
        public User Login(string login,string password)
        {
            _query = Query<User>.Where(x => x.Login.Equals(login) && x.Password.Equals(password));

           return GetCollection<User>().FindOne(_query);
        }

        public User teste()
        {
            return FindById<User>("");
        }
    }
}