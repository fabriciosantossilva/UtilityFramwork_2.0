using UtilityFramework.Data.Repository.Models;

namespace UtilityFramework.TestApplication.Data
{
    public class User : ModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public override string CollectionName => nameof(User);
    }
}
