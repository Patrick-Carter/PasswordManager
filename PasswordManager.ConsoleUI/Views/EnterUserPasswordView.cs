using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.Views
{
    public class EnterUserPasswordView : IView
    {
        public string Display()
        {
            Console.WriteLine("Enter Password...");
            string input = Console.ReadLine();
            return input;
        }
    }
}
