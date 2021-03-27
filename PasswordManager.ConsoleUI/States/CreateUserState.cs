using PasswordManager.ConsoleUI.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.States
{
    public class CreateUserState : IState
    {
        private IStateMachine stateMachine;
        private IView usernameView;

        public CreateUserState(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            usernameView = new EnterUsernameView();
        }
        public void DisplayView()
        {
            string res = usernameView.Display();
        }
    }
}
