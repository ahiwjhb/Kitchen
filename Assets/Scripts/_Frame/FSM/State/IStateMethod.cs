using System;

namespace FSM
{
    public interface IStateMethod<StateEnum> where StateEnum : Enum
    {
        public StateEnum Type { get; }

        public void EnterState();

        public void UpdateState();

        public void FixedUpdateState();

        public void ExitState();

    }
}
