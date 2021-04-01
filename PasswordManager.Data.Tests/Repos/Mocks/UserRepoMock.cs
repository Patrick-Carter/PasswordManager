using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManager.Data.Tests.Repos.Mocks
{
    class UserRepoMock : IUserRepo
    {
        public List<UserModel> ListOfUsers { get; } = new List<UserModel>
            {
                new UserModel("TakenUserName", "12345"),
                new UserModel("Nelly", "12345"),
                new UserModel("Kert", "12345")
            };

        public UserRepoMock()
        {
            
        }

        public UserModel CreateUser(string username, string password)
        {
            if (FindUser(username) == null)
            {
                UserModel user = new UserModel(username, password);
                return user;
            }
            return null;
        }

        public UserModel FindUser(string username)
        {
            return this.ListOfUsers.Where(q => q.UserName == username).FirstOrDefault();
        }
    }
}
