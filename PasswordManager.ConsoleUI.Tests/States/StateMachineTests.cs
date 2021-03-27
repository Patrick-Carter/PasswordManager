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
            Assert.That(stateMachine.CurrentState, Is.InstanceOf<EntryPointState>());
        }

    }
}
