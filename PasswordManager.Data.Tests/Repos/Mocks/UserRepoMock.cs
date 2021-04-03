using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System.Collections.Generic;
using System.Linq;

namespace PasswordManager.Data.Tests.Repos.Mocks
{
    public class UserRepoMock : IRepo<UserModel>
    {
        public List<UserModel> ListOfItems { get; } = new List<UserModel>
            {
                new UserModel("TakenUserName", "12345"),
                new UserModel("Nelly", "12345"),
                new UserModel("Kert", "12345")
            };

        public UserRepoMock()
        {
            
        }

        public UserModel Create(UserModel user)
        {
            if (GetByName(user.UserName) == null)
            {
                ListOfItems.Add(user);
                return user;
            }
            return null;
        }

        public UserModel GetByName(string searchTerm)
        {
            return this.ListOfItems.Where(q => q.UserName == searchTerm).FirstOrDefault();
        }

        public void Remove(UserModel model)
        {
            ListOfItems.Remove(model);
        }
    }
}
