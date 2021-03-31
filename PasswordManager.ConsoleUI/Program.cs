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

            while (true)
            {
                Console.Clear();
                Console.WriteLine("create a user or find a user? ['create'/'find']");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "create")
                {
                    Console.WriteLine("enter username...");
                    var username = Console.ReadLine();
                    Console.WriteLine("enter password...");
                    var password = Console.ReadLine();
                    var userToAdd = uow.userRepo.CreateUser(username, password);
                    uow.AddUserToDB(userToAdd);
                }
                else if (answer.ToLower() == "find")
                {
                    Console.WriteLine("Enter username of user you'd like to find");
                    var username = Console.ReadLine();
                    var user = uow.userRepo.FindUser(username);
                    if (user == null)
                    {
                        Console.WriteLine($"No user with the username of {username} was found.");
                    }
                    else
                    {
                        Console.WriteLine($"{username} was found and has an ID of {user.Id}");
                    }
                    Console.WriteLine("press enter to find or create another user...");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("invalid input press Enter to try again...");
                    Console.ReadLine();
                }
            }
        }

       
    }
}
