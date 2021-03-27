using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.States
{
    public interface IStateMachine
    {
        public IState EntryPointState { get; }
        public IState CreateUserState { get; }
        public IState CurrentState { get; set; }
        public void DisplayView();
    }
}
