using System;

namespace FSM
{
    public interface IStateContainer<StateEnum, ContextClass> where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        public IStateMethod<StateEnum> GetStateMethod(StateEnum stateEnum);

        public IStateEvent GetStateEvent(StateEnum stateEnum);
    }
}

