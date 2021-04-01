using NUnit.Framework;
using PasswordManager.Data.Model;
using PasswordManager.Data.Tests.Repos.Mocks;
using PasswordManager.Data.Tests.UnitOfWork.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.UnitOfWork
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void AddUserToDB_NewUserPassed_ListAmountIncreasedByOne()
        {
            
            UnitOfWorkMock uowMock = new UnitOfWorkMock();
            int count = uowMock.userRepo.ListOfUsers.Count;

            UserModel newUser = uowMock.userRepo.CreateUser("Patrick", "12345");
            uowMock.AddUserToDB(newUser);

            Assert.That(uowMock.userRepo.ListOfUsers.Count, Is.EqualTo(count + 1));
        }

        [Test]
        public void AddUserToDB_UserAlreadyInDB_NoUsersAddedToList()
        {
            
            UnitOfWorkMock uowMock = new UnitOfWorkMock();
            int count = uowMock.userRepo.ListOfUsers.Count;

            UserModel newUser = uowMock.userRepo.CreateUser("TakenUserName", "12345");

            if (newUser != null)
            {
                uowMock.AddUserToDB(newUser);
            }

            Assert.That(uowMock.userRepo.ListOfUsers.Count, Is.EqualTo(count));
        }
    }
}
