using System;

namespace FSM
{
    public interface IFSMPublic<StateEnum> where StateEnum : Enum
    {
        public event Action<StateEnum> OnStateChange;

        public IStateEvent GetStateEvent(StateEnum stateEnum);

        public StateEnum CurrentStateType { get; }
    }
}
