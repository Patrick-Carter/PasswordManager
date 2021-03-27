using PasswordManager.ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.States
{
    public class EntryPointState : IState
    {
        private IStateMachine stateMachine;
        private IView entryView;
        private IView loginView;

        public EntryPointState(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            entryView = new EntryPointView();
            loginView = new LoginView();
        }
        private void Create()
        {
            throw new NotImplementedException();
        }

        public void DisplayView()
        {
            string input = entryView.Display();

            if (input.ToLower() == "create") stateMachine.CurrentState = stateMachine.EntryPointState;
            else Login(input);
        }

        private void Login(string userName)
        {
            string input = loginView.Display();
        }
    }
}
