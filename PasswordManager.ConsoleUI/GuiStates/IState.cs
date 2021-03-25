using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.GuiStates
{
    public interface IState
    {
        public void CreateUser();
        public void Login();
        public void Logout();
        public void EnterPasswordName();
        public void Exit();
        public void Delete();
        public void Update();
        public void EnteredUserPassword();
        public void EnteredUserName();
    }
}
