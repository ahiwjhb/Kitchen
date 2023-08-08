using System;

namespace FSM
{
    public interface ICanStateChange<StateEnum> where StateEnum : Enum
    {
        public void SwitchState(StateEnum stateEnum);

        public void SetCurrentState(StateEnum stateEnum);
    }
}
