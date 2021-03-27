using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.Views
{
    public class EntryPointView : IView
    {
        public string Display()
        {
            Console.WriteLine("Enter username or type 'create' to create a new user...");
            string input = Console.ReadLine();
            return input;
        }
    }
}
