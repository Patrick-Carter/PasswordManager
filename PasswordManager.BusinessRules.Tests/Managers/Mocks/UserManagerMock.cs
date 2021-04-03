using PasswordManager.BusinessRules.Managers;
using PasswordManager.Data.dbProcessors;
using PasswordManager.Data.Model;
using PasswordManager.Data.Tests.dbProcessors.Mocks;

namespace PasswordManager.BusinessRules.Tests.Managers.Mocks
{
    public class UserManagerMock : IUserManager
    {
        private UserModel currentUser;
        private IdbProcesser<UserModel> uow;

        public UserManagerMock(IdbProcesser<UserModel> unitOfWork = null)
        {
            uow = unitOfWork ?? new UserdbProcessorMock();
        }

        public UserModel GetCurrentUser()
        {
            return currentUser;
        }

        public void LoginUser(string userName, string password)
        {
            var user = uow.userRepo.GetByName(userName);

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
                uow.RemoveFromDB(currentUser);
                currentUser = null;
            }
        }
    }
}
