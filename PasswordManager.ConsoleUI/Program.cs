using PasswordManager.ConsoleUI.GuiViews;
using System;

namespace PasswordManager.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var view = View.getInstance();
            view.DisplayGui();
        }
    }
}
