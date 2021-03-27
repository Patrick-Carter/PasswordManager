using Moq;
using NUnit.Framework;
using PasswordManager.ConsoleUI.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace PasswordManager.ConsoleUI.Tests.States
{
    [TestFixture]
    public class StateMachineTests
    {
        private IStateMachine stateMachine; 

        [SetUp]
        public void Init()
        {
            stateMachine = StateMachine.GetInstance();
        }

        [Test]
        public void NewStateMachine_StateMachineCreated_stateMachineNotNull()
        {
            Assert.That(stateMachine, Is.Not.Null);
        }

        [Test]
        public void NewStateMachine_StateMachineCreated_EntryPointStateNotNull()
        {
            Assert.That(stateMachine.EntryPointState, Is.Not.Null);
        }

        [Test]
        public void NewStateMachine_StateMachineCreated_CreateUserStateNotNull()
        {
            Assert.That(stateMachine.CreateUserState, Is.Not.Null);
        }

        [Test]
        public void DisplayView_WhenCalled_CallesCurrentStateToDispalyView()
        {
            var sm = new Mock<IStateMachine>();
            sm.Object.DisplayView();

            sm.Verify(a => a.DisplayView(), Times.Once());
        }

    }
}
