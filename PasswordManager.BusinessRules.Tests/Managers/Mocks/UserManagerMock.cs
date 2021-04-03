using PasswordManager.BusinessRules.Managers;
using PasswordManager.Data.Tests.Repos.Mocks;
using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;

namespace PasswordManager.BusinessRules.Tests.Managers.Mocks
{
    public class UserManagerMock : IUserManager
    {
        private UserModel currentUser;
        private IRepo<UserModel> userRepo;

        public UserManagerMock(IRepo<UserModel> userRepo = null)
        {
            this.userRepo = userRepo ?? new UserRepoMock();
        }

        public UserModel GetCurrentUser()
        {
            return currentUser;
        }

        public void LoginUser(string userName, string password)
        {
            var user = userRepo.GetByName(userName);

            if (user == null || user.Password != password) 
            {
                return;
            }

            if (password == user.Password)
            {
                currentUser = user;
            }
        }

        public void LogoutUser()
        {
            currentUser = null;
        }

        public void RemoveUser(string password)
        {
            if (password == currentUser.Password)
            {
                userRepo.Remove(currentUser);
                currentUser = null;
            }
        }
    }
}
