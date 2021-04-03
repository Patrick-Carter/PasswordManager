using PasswordManager.Data.Model;
using PasswordManager.Data.Repos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.Data.Tests.Repos.Mocks
{
    public class PasswordRepoMock : IRepo<PasswordModel>
    {
        public List<PasswordModel> ListOfItems { get; } = new List<PasswordModel>
        {
            new PasswordModel("gmail", "12345")

        };


        public PasswordModel Create(PasswordModel model)
        {
            throw new NotImplementedException();
        }

        public PasswordModel GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Remove(PasswordModel model)
        {
            throw new NotImplementedException();
        }
    }
}
