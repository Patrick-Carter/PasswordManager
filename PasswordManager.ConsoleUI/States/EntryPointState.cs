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

        public EntryPointState(IStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
            entryView = new EntryPointView();
        }
        private void Create()
        {
            stateMachine.CurrentState = stateMachine.CreateUserState;
        }

        public void DisplayView()
        {
            string res = entryView.Display();

            if (res.ToLower() == "create") Create();
            else Login(res);
        }

        private void Login(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
