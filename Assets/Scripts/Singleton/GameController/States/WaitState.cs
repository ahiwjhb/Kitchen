using Helper;
using FSM;

public partial class GameController
{
   private class WaitState : State<GameState, GameController>
   {
        private Timer waitTimer = new Timer();

        public override GameState Type => GameState.Wait;

        public override void EnterState() {
            base.EnterState();
            waitTimer.ReStart(ctx.playGameWaitTimeSecond);
        }

        public override void UpdateState() {
            base.UpdateState();

            if (waitTimer.IsTimeUp()) {
                ctx.fsm.SwitchState(GameState.Playing);
            }

            if (PlayerInput.Instance.IsPauseKeyDown) {
                ctx.fsm.SwitchState(GameState.Pause);
            }
        }
    }
}
