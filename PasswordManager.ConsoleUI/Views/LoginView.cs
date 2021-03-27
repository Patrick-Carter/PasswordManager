using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.Views
{
    public class LoginView : IView
    {
        public string Display()
        {
            Console.WriteLine("Please enter password...");
            string input = Console.ReadLine();
            return input;
        }
    }
}
