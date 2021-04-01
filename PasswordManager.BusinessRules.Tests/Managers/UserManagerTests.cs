using NUnit.Framework;
using PasswordManager.BusinessRules.Managers;
using PasswordManager.BusinessRules.Tests.Managers.Mocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.BusinessRules.Tests.Managers
{
    [TestFixture]
    public class UserManagerTests
    {
        private IUserManager userManager;

        [SetUp]
        public void Init()
        {
            userManager = new UserManagerMock();
        }

        [Test]
        public void LoginUser_CorrectUsernameAndPassword_UserLoggedIn()
        {
            userManager.LoginUser("TakenUserName", "12345");
            Assert.That(userManager.GetCurrentUser(), Is.Not.Null);
        }
        [Test]
        public void LoginUser_WrongUsernameAndPassword_UserNotLoggedIn()
        {
            userManager.LoginUser("NotAUser", "12345");
            Assert.That(userManager.GetCurrentUser(), Is.Null);
        }
        [Test]
        public void LoginUser_PasswordWasIncorrect_UserNotLoggedIn()
        {
            userManager.LoginUser("TakenUserName", "WrongPassword");
            Assert.That(userManager.GetCurrentUser(), Is.Null);
        }
        [Test]
        public void LogoutUser_WhenCalled_LogOutUser()
        {
            userManager.LoginUser("TakenUserName", "12345");
            userManager.LogoutUser();
            Assert.That(userManager.GetCurrentUser(), Is.Null);
        }
    }
}
