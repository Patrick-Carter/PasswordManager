using PasswordManager.ConsoleUI.GuiStates;
using System;

namespace PasswordManager.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------Password Manager-------------");
            var stateMachine = StateMachine.getInstance();


            while(stateMachine.GetState() == stateMachine.EntryPointState)
            {
                Console.WriteLine("Enter username or type 'create' to create new user...");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "create")
                    stateMachine.SetState(stateMachine.CreateUserState);
                else
                {
                    //Enter username and password
                }
            }
            while (stateMachine.GetState() == stateMachine.CreateUserState)
            {
                Console.Clear();
                Console.WriteLine("-------------Create New User-------------");
                Console.WriteLine("Please enter your prefered username...");
                string username = Console.ReadLine();
            }
            while (stateMachine.GetState() == stateMachine.DashbaordState)
            {

            }
            while (stateMachine.GetState() == stateMachine.DisplayPasswordsState)
            {

            }
            while (stateMachine.GetState() == stateMachine.UpdateUserState)
            {

            }
            while (stateMachine.GetState() == stateMachine.DeletePasswordState)
            {

            }
            while (stateMachine.GetState() == stateMachine.UpdatePasswordState)
            {

            }
            while (stateMachine.GetState() == stateMachine.UpdateUserUsernameState)
            {

            }
            while (stateMachine.GetState() == stateMachine.UpdateUserPasswordState)
            {

            }
        }
    }
}
