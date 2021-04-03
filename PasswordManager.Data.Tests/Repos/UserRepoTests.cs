using NUnit.Framework;
using PasswordManager.Data.dbProcessors;
using PasswordManager.Data.Model;
using PasswordManager.Data.Tests.dbProcessors.Mocks;

namespace PasswordManager.Data.Tests.Repos
{
    [TestFixture]
    public class UserRepoTests
    {
        [Test]
        public void CreateUser_UniqueUserMade_NewUserCreated()
        {
            IdbProcesser<UserModel> uow = new UserdbProcessorMock();
            UserModel newUser = uow.userRepo.Create("Patrick", "12345");

            Assert.That(newUser.UserName, Is.EqualTo("Patrick"));
            Assert.That(newUser.Password, Is.EqualTo("12345"));
            Assert.That(newUser, Is.InstanceOf<UserModel>());
        }

        [Test]
        public void CreateUser_UsernameAlreadyInUse_ReturnNull()
        {
            IdbProcesser<UserModel> uow = new UserdbProcessorMock();
            UserModel newUser = uow.userRepo.Create("TakenUserName", "12345");

            Assert.That(newUser, Is.Null);
        }
        
        [Test]
        public void FindUser_LookingForUserInDB_ReturnUserObject()
        {
            IdbProcesser<UserModel> uow = new UserdbProcessorMock();
            UserModel userToFind = new UserModel("TakenUserName", "12345");

            UserModel user = uow.userRepo.GetByName(userToFind.UserName);

            Assert.That(user, Is.Not.Null);
        }
        [Test]
        public void FindUser_LookingForUserNotInDB_ReturnNull()
        {
            IdbProcesser<UserModel> uow = new UserdbProcessorMock();
            UserModel userToFind = new UserModel("NotInDB", "12345");

            UserModel user = uow.userRepo.GetByName(userToFind.UserName);

            Assert.That(user, Is.Null);
        }
    }
}
