
using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.BusinessRules.Managers
{
    public class UserManager : IUserManager
    {
        private UserModel currentUser;
        private IRepo<UserModel> userRepo;

        public UserManager(IRepo<UserModel> userRepo = null)
        {
            this.userRepo = userRepo ?? new UserRepo();
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
