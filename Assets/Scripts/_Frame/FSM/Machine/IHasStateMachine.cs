using System;

namespace FSM
{
    public interface IHasStateMachine<StateEnum> where StateEnum : Enum
    {
        public IStateMechinePublic<StateEnum> FSM { get; }
    }
}
