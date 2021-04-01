using PasswordManager.BusinessRules.Managers;
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
                Console.WriteLine("create a user or login? ['create'/'login']");
                var answer = Console.ReadLine();
                if (answer.ToLower() == "create")
                {
                    Console.WriteLine("enter username...");
                    var username = Console.ReadLine();
                    while (true)
                    {
                        
                        if (uow.userRepo.FindUser(username) != null)
                        {
                            Console.WriteLine("username already in use. Please Try again...");
                            username = Console.ReadLine();
                        }
                        else
                        {
                            break;
                        }
                    }
                    
                    Console.WriteLine("enter password...");
                    var password = Console.ReadLine();
                    var userToAdd = uow.userRepo.CreateUser(username, password);
                    uow.AddUserToDB(userToAdd);
                }
                else if (answer.ToLower() == "login")
                {
                    IUserManager userManager = new UserManager(uow);
                    Console.WriteLine("enter your username...");
                    var userName = Console.ReadLine();
                    Console.WriteLine("enter your password...");
                    var password = Console.ReadLine();
                    userManager.LoginUser(userName, password);
                    while (userManager.GetCurrentUser() == null)
                    {
                        Console.WriteLine("Invalid user credentials. Please try again.");
                        Console.WriteLine("enter your username...");
                        userName = Console.ReadLine();
                        Console.WriteLine("enter your password...");
                        password = Console.ReadLine();
                        
                        userManager.LoginUser(userName, password);
                    }

                    while (userManager.GetCurrentUser() != null)
                    {
                        var user = userManager.GetCurrentUser();
                        Console.WriteLine($"Hello {user.UserName}, Type 'logout' to logout or 'remove' to remove this account.");
                        var input = Console.ReadLine();
                        if (input.ToLower() == "logout")
                        {
                            userManager.LogoutUser();
                            Console.WriteLine("You have been logged out. Press enter to continue...");
                            Console.ReadLine();
                        }
                        else if (input.ToLower() == "remove")
                        {
                            Console.WriteLine("Enter your current user password to delete your account...");
                            input = Console.ReadLine();
                            if (input == user.Password)
                            {
                                userManager.RemoveUser(input);
                                Console.WriteLine("Account deleted. Press enter to continue...");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("invaild password. Account was not deleted.");
                            }
                           
                        }
                    }

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
