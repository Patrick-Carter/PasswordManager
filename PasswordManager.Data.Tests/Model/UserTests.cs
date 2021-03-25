using NUnit.Framework;
using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.Model
{
    [TestFixture]
    public class UserTests
    {

        private User user;

        [SetUp]
        public void Init()
        {
            this.user = new User("Patrick", "1234");
        }


        [Test]
        public void NewUser_NewUserWasCreated_GuidWasCreated()
        {
            Assert.That(user.Id, Is.Not.Null);
        }
        [Test]
        public void NewUser_NewUserWasCreate_UsernameWasInitialized()
        {
            Assert.That(user.UserName, Is.Not.Null);
        }

        [Test]
        public void NewUser_NewUserWasCreated_PasswordWasInitialized()
        {
            Assert.That(user.Password, Is.Not.Null);
        }
    }
}
