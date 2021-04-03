using NUnit.Framework;
using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using PasswordManager.Data.Tests.Repos.Mocks;

namespace PasswordManager.Data.Tests.Repos
{
    [TestFixture]
    public class UserRepoTests
    {
        private IRepo<UserModel> userRepo;
        private UserModel newUser;
        private UserModel takenUser;

        [SetUp]
        public void Init()
        {
            userRepo = new UserRepoMock();
            newUser = new UserModel("NotTaken", "12345");
            takenUser = new UserModel("TakenUserName", "12345");
        }

        [Test]
        public void CreateUser_UniqueUserMade_NewUserCreated()
        {
            int count = userRepo.ListOfItems.Count;

            userRepo.Create(newUser);

            Assert.That(userRepo.ListOfItems.Count, Is.EqualTo(count + 1));
            Assert.That(newUser.UserName, Is.EqualTo("NotTaken"));
            Assert.That(newUser.Password, Is.EqualTo("12345"));
            Assert.That(newUser, Is.InstanceOf<UserModel>());
        }

        [Test]
        public void CreateUser_UsernameAlreadyInUse_ReturnNull()
        {
            int count = userRepo.ListOfItems.Count;

            UserModel takenUserLocal = userRepo.Create(takenUser);

            Assert.That(userRepo.ListOfItems.Count, Is.EqualTo(count));
            Assert.That(takenUserLocal, Is.Null);
        }
        
        [Test]
        public void FindUser_LookingForUserInDB_ReturnUserObject()
        {
            UserModel user = userRepo.GetByName(takenUser.UserName);

            Assert.That(user, Is.Not.Null);
        }
        [Test]
        public void FindUser_LookingForUserNotInDB_ReturnNull()
        {
            UserModel user = userRepo.GetByName(newUser.UserName);

            Assert.That(user, Is.Null);
        }

        [Test]
        public void Remove_WhenCalled_RemovesUserFromDB()
        {
            userRepo.Create(newUser);

            int count = userRepo.ListOfItems.Count;

            userRepo.Remove(newUser);

            Assert.That(userRepo.ListOfItems.Count, Is.EqualTo(count - 1));

        }
    }
}
