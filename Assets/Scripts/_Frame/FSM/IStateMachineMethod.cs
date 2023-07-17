using System;

namespace FSM
{
    public interface IStateMachineMethod<StateEnum, ContextClass> where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        public void EnterState();

        public void FixedUpdateState();

        public void UpdateState();

        public void ExitState();

        public void SwitchState(StateEnum stateEnum);

        public void SetCurrentState(StateEnum stateEnum);
    }
}
