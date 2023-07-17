﻿using System;

namespace FSM
{
    public interface IStateMachineEvent<StateEnum> where StateEnum : Enum
    {
        public event Action<StateEnum> OnStateChange;

        public IStateEvent GetStateEvent(StateEnum stateEnum);

        public StateEnum CurrentState { get; }
    }
}
