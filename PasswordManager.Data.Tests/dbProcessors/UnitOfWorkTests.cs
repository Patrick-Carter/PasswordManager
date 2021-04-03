using NUnit.Framework;
using PasswordManager.Data.Model;
using PasswordManager.Data.Tests.dbProcessors.Mocks;
using PasswordManager.Data.Tests.Repos.Mocks;
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
            
            UserdbProcessorMock uowMock = new UserdbProcessorMock();
            int count = uowMock.userRepo.ListOfItems.Count;

            UserModel newUser = uowMock.userRepo.Create("NotAUser", "12345");
            uowMock.AddToDB(newUser);

            Assert.That(uowMock.userRepo.ListOfItems.Count, Is.EqualTo(count + 1));
        }

        [Test]
        public void AddUserToDB_UserAlreadyInDB_NoUsersAddedToList()
        {
            
            UserdbProcessorMock uowMock = new UserdbProcessorMock();
            int count = uowMock.userRepo.ListOfItems.Count;

            UserModel newUser = uowMock.userRepo.Create("TakenUserName", "12345");

            if (newUser != null)
            {
                uowMock.AddToDB(newUser);
            }

            Assert.That(uowMock.userRepo.ListOfItems.Count, Is.EqualTo(count));
        }

        [Test]
        public void RemoveUserFromDB_WhenCalled_RemovesUserFromDB()
        {
            UserdbProcessorMock uowMock = new UserdbProcessorMock();
            UserModel newUser = uowMock.userRepo.Create("NotAUser", "12345");
            uowMock.AddToDB(newUser);

            int count = uowMock.userRepo.ListOfItems.Count;

            uowMock.RemoveFromDB(newUser);

            Assert.That(uowMock.userRepo.ListOfItems.Count, Is.EqualTo(count - 1));

        }
    }
}
