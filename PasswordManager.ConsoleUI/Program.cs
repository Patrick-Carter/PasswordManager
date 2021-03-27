using PasswordManager.ConsoleUI.States;
using System;

namespace PasswordManager.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IStateMachine stateMachine = StateMachine.GetInstance();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("---PASSWORD MANAGER---");
                stateMachine.DisplayView();
            }

        }
    }
}
