using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.GuiStates
{
    public class CreateUserState : IState
    {
        StateMachine StateMachine;

        public CreateUserState(StateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }
        public void CreateUser()
        {
            throw new NotImplementedException();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void EnteredUserName()
        {
            throw new NotImplementedException();
        }

        public void EnteredUserPassword()
        {
            throw new NotImplementedException();
        }

        public void EnterPasswordName()
        {
            throw new NotImplementedException();
        }

        public void Exit()
        {
            throw new NotImplementedException();
        }

        public void Login()
        {
            throw new NotImplementedException();
        }

        public void Logout()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
