using Helper;
using FSM;

public partial class StoveCounter
{
    private class OverDoingState : State<StoveState, StoveCounter>
    {
        private Timer burnedTimer = new Timer();

        public override StoveState Type => StoveState.OverDoing;

        public override void EnterState() {
            base.EnterState();
            burnedTimer.ReStart(ctx.fryingFormula.burnedTime);
        }

        public override void UpdateState() {
            base.UpdateState();
            if (burnedTimer.IsTimeUp()) {
                ctx.GetBePlacedKitchenObject().DestroySelf();
                KitchenObject.Creat(ctx.fryingFormula.burnedOutput, ctx);
                ctx.fsm.SwitchState(StoveState.Burned);
            }
            ctx.OnProcessChange?.Invoke(burnedTimer.Progress());
        }
    }
}
