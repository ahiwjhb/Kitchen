using System;
namespace FSM
{
    public abstract class InterruptState<StateEnum, ContextClass> : State<StateEnum, ContextClass> where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        private StateEnum lastStateEnum;

        public override void EnterState() {
            base.EnterState();
            lastStateEnum = ctx.FSM.CurrentStateType;
        }

        public void Back() {
            ExitState();
            if(ctx.FSM.GetStateEvent(lastStateEnum) is InterruptState<StateEnum, ContextClass>) {
                (ctx.FSM.GetStateEvent(lastStateEnum) as InterruptState<StateEnum, ContextClass>).Back();
            }
            else {
                (ctx.FSM as ICanStateChange<StateEnum>).SetCurrentState(lastStateEnum);
            }
        }
    }
}
