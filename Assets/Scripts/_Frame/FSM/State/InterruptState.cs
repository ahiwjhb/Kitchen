using System;
namespace FSM
{
    public abstract class InterruptState<StateEnum, ContextClass> : State<StateEnum, ContextClass> where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        private StateEnum lastState;

        public override void EnterState() {
            base.EnterState();
            lastState = ctx.FSM.CurrentState;
        }

        public void Back() {
            ExitState();
            if(lastState is InterruptState<StateEnum, ContextClass>) {
                (lastState as InterruptState<StateEnum, ContextClass>).Back();
            }
            else {
                (ctx.FSM as IStateMachineMethod<StateEnum, ContextClass>).SetCurrentState(lastState);
            }
        }
    }
}
