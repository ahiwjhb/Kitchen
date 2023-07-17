using FSM;
using Helper;
using System;
using System.Diagnostics;

public partial class StoveCounter
{
    public event Action<float> OnProcessChange;

    private class FryingState : State<StoveState, StoveCounter>
    {
        private Timer frytingTimer = new Timer();

        public override StoveState Type => StoveState.Frying;

        public override void EnterState() {
            base.EnterState();
            frytingTimer.ReStart(ctx.fryingFormula.fryingTime);
        }

        public override void UpdateState() {
            base.UpdateState();
            ctx.OnProcessChange?.Invoke(frytingTimer.Progress());
            if (frytingTimer.IsTimeUp()) {
                ctx.GetBePlacedKitchenObject().DestroySelf();
                KitchenObject.Creat(ctx.fryingFormula.normalOutput, ctx);
                ctx.fsm.SwitchState(StoveState.OverDoing);
            }
        }
    }
}
