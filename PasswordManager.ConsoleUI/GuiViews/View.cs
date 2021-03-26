using PasswordManager.States.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.GuiViews
{
    public class View
    {
        private StateMachine stateMachine;
        private static View uniqueInstance;
        private View()
        {
            var stateMachine = StateMachine.getInstance();
        }

        public static View getInstance()
        {
           if (uniqueInstance == null)
            {
                uniqueInstance = new View();
            }

            return uniqueInstance;
        }
        public void DisplayGui()
        {
            while (stateMachine.GetState() == stateMachine.EntryPointState)
            {

            }
            while (stateMachine.GetState() == stateMachine.CreateUserState)
            {

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
