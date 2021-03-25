using NUnit.Framework;
using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.Model
{
    [TestFixture]
    public class PasswordModelTests
    {

        private PasswordModel passwordWithWebsite;
        private PasswordModel passwordWithoutWebsite;

        [SetUp]
        public void Init()
        {
            UserModel user = new UserModel("Patrick", "1234");

            passwordWithoutWebsite = new PasswordModel("Facebook", "12345", user);
            passwordWithWebsite = new PasswordModel("Facebook", "12345", user,"https://facebook.com");
        }

        [Test]
        public void NewPassword_PasswordWasCreatedWithoutWebsite_OnlyWebsiteProIsNull()
        {
            Assert.That(passwordWithoutWebsite.Id, Is.Not.Null);
            Assert.That(passwordWithoutWebsite.Name, Is.Not.Null);
            Assert.That(passwordWithoutWebsite.Code, Is.Not.Null);
            Assert.That(passwordWithoutWebsite.User, Is.Not.Null);
            Assert.That(passwordWithoutWebsite.Website, Is.Null);
        }

        [Test]
        public void NewPassword_PasswordWasCreatedWithWebsite_NothingIsNull()
        {
            Assert.That(passwordWithWebsite.Id, Is.Not.Null);
            Assert.That(passwordWithWebsite.Name, Is.Not.Null);
            Assert.That(passwordWithWebsite.Code, Is.Not.Null);
            Assert.That(passwordWithoutWebsite.User, Is.Not.Null);
            Assert.That(passwordWithWebsite.Website, Is.Not.Null);
        }
    }
}
