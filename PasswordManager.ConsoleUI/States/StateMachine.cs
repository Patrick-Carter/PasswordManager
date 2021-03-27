using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.States
{
    public class StateMachine : IStateMachine
    {
        public IState EntryPointState { get; }
        public IState CreateUserState { get; }
        public IState CurrentState { get; set; }

        private static IStateMachine uniqueInstance; 

        private StateMachine()
        {
            EntryPointState = new EntryPointState(this);
            CreateUserState = new CreateUserState(this);
            CurrentState = EntryPointState;
        }

        public static IStateMachine GetInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new StateMachine();
            }
            return uniqueInstance;
        }

        public void DisplayView()
        {
            CurrentState.DisplayView();
        }
    }
}
