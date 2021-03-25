using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.GuiStates
{
    public class StateMachine
    {
        public IState EntryPointState { get; }
        public IState CreateUserState { get; }
        public IState DashbaordState { get; }
        public IState DisplayPasswordsState { get; }
        public IState UpdateUserState { get; }
        public IState DeletePasswordState { get; }
        public IState UpdatePasswordState { get; }
        public IState UpdateUserUsernameState { get; }
        public IState UpdateUserPasswordState { get; }

        private IState currentState;

        private static StateMachine uniqueInstance;

        private StateMachine()
        {
            EntryPointState = new EntryPointState(this);
            CreateUserState = new CreateUserState(this);
            DashbaordState = new DashboardState(this);
            DisplayPasswordsState = new DisplayPasswordsState(this);
            UpdatePasswordState = new UpdateUserState(this);
            DeletePasswordState = new DeletePasswordState(this);
            UpdatePasswordState = new UpdatePasswordState(this);
            UpdateUserUsernameState = new UpdateUserUsernameState(this);
            UpdateUserPasswordState = new UpdateUserPasswordState(this);
            currentState = this.EntryPointState;
        }

        public static StateMachine getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new StateMachine();
            }
            return uniqueInstance;
        }

        public IState GetState()
        {
            return currentState;
        }
        public void SetState(IState newState)
        {
            currentState = newState;
        }

        public void CreateUser()
        {
            currentState.CreateUser();
        }

        public void Login()
        {
            currentState.Login();
        }

        public void Logout()
        {
            currentState.Logout();
        }
        public void EnterPasswordName()
        {
            currentState.EnterPasswordName();
        }
        public void Exit()
        {
            currentState.Exit();
        }
        public void Delete()
        {
            currentState.Delete();
        }
        public void Update()
        {
            currentState.Update();
        }
        public void EnteredUserPassword()
        {
            currentState.EnteredUserPassword();
        }
        public void EnteredUsername()
        {
            currentState.EnteredUserName();
        }
    }
}
