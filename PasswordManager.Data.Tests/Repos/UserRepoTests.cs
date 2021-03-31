using NUnit.Framework;
using PasswordManager.Data.Model;
using PasswordManager.Data.Tests.Repos.Mocks;
using PasswordManager.Data.Tests.UnitOfWork.Mocks;
using PasswordManager.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.Repos
{
    [TestFixture]
    public class UserRepoTests
    {
        [Test]
        public void CreateUser_WhenCalled_NewUserCreated()
        {
            IUnitOfWork uow = new UnitOfWorkMock();

            UserModel newUser = uow.userRepo.CreateUser("Patrick", "12345");

            Assert.That(newUser.UserName, Is.EqualTo("Patrick"));
            Assert.That(newUser.Password, Is.EqualTo("12345"));
            Assert.That(newUser, Is.InstanceOf<UserModel>());
        }
        
        [Test]
        public void FindUser_LookingForUserInDB_ReturnUserObject()
        {
            IUnitOfWork uow = new UnitOfWorkMock();
            UserModel userToFind = new UserModel("TakenUserName", "12345");

            UserModel user = uow.userRepo.FindUser(userToFind.UserName);

            Assert.That(user, Is.Not.Null);
        }
        [Test]
        public void FindUser_LookingForUserNotInDB_ReturnNull()
        {
            IUnitOfWork uow = new UnitOfWorkMock();
            UserModel userToFind = new UserModel("NotInDB", "12345");

            UserModel user = uow.userRepo.FindUser(userToFind.UserName);

            Assert.That(user, Is.Null);
        }
    }
}
