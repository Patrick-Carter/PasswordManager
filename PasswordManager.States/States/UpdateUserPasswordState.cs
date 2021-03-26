using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.States.States
{
    public class UpdateUserPasswordState : IState
    {
        StateMachine StateMachine;

        public UpdateUserPasswordState(StateMachine stateMachine)
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
