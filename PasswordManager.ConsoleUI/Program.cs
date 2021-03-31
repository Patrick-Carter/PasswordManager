using PasswordManager.Data.Model;
using PasswordManager.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.IO;

namespace PasswordManager.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnitOfWork uow = new UnitOfWork();
            UserModel user = new UserModel("Patrick", "12345");

            UserModel u = uow.userRepo.FindUser(user);

            if (u != null)
            {
                Console.WriteLine($"{u.Id},{u.UserName},{u.Password}");
            }
            else
            {
                Console.WriteLine("user not found");
            }
            
            Console.ReadLine();
        }

       
    }
}
