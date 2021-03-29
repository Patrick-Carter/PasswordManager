using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.Views
{
    public class ConfirmPasswordView : IView
    {
        public string Display()
        {
            Console.WriteLine("Confirm password...");
            string input = Console.ReadLine();
            return input;
        }
    }
}
