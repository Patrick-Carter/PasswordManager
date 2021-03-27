using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.Views
{
    public class EnterUsernameView : IView
    {
        public string Display()
        {
            Console.WriteLine("Enter Username...");
            var input = Console.ReadLine();
            return input;
        }
    }
}
