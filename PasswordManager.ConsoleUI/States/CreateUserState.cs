using PasswordManager.ConsoleUI.Views;
using PasswordManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.States
{
    public class CreateUserState : IState
    {
        private IStateMachine stateMachine;
        private IView usernameView;
        private IView enterPasswordView;
        private IView confirmPasswordView;

        public CreateUserState(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            usernameView = new EnterUsernameView();
            enterPasswordView = new EnterUserPasswordView();
            confirmPasswordView = new ConfirmPasswordView();
        }
        public void DisplayView()
        {
            string userName = usernameView.Display();
            string password = enterPasswordView.Display();
            string confirmPassword = confirmPasswordView.Display();

            // if the username is unique
            UserModel newUser = new UserModel(userName, password);
        }
    }
}
