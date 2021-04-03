using PasswordManager.Data.dbProcessors;
using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using PasswordManager.Data.Tests.Repos.Mocks;

namespace PasswordManager.Data.Tests.dbProcessors.Mocks
{
    public class UserdbProcessorMock : IdbProcesser<UserModel>
    {
        public IRepo<UserModel> userRepo { get; }

        public UserdbProcessorMock(IRepo<UserModel> userRepo = null)
        {
            this.userRepo = userRepo ?? new UserRepoMock();
        }
        public void AddToDB(UserModel user)
        {
            if (ValidUser(user))
            {
                userRepo.ListOfItems.Add(user);
            }
        }

        public void RemoveFromDB(UserModel user)
        {
            userRepo.ListOfItems.Remove(user);
        }

        private bool ValidUser(UserModel user)
        {
            if (userRepo.GetByName(user.UserName) == null)
            {
                return true;
            }
            return false;
        }
    }
}
