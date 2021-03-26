using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.States.States
{
    public interface IState
    {
        public void Create();
        public void EnterName();
        public void EnterPassword();
        public void Exit();
        public void Delete();
        public void Update();
    }
}
