using System;

namespace FSM
{
    public interface IHasStateMachine<StateEnum> where StateEnum : Enum
    {
        public IFSMPublic<StateEnum> FSM { get; }
    }
}
