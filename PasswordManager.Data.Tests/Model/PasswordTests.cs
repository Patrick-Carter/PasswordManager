using NUnit.Framework;
using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.Model
{
    [TestFixture]
    public class PasswordTests
    {

        private Password passwordWithWebsite;
        private Password passwordWithoutWebsite;

        [SetUp]
        public void Init()
        {
            User user = new User("Patrick", "1234");

            passwordWithoutWebsite = new Password("Facebook", "12345", user);
            passwordWithWebsite = new Password("Facebook", "12345", user,"https://facebook.com");
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
