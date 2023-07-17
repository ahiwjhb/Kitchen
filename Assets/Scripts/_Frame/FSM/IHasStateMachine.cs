using System;

namespace FSM
{
    public interface IHasStateMachine<StateEnum> where StateEnum : Enum
    {
        public IStateMachineEvent<StateEnum> FSM { get; }
    }
}
