using FSM;
using Helper;

public partial class GameController
{
    private class PlayingState : State<GameState, GameController>
    {
        private Timer playingGameTimer = new Timer();

        public override GameState Type => GameState.Playing;

        public override void EnterState() {
            base.EnterState();
            PlayerInput.Instance.Enable();
            playingGameTimer.ReStart(ctx.playGameTimeSecond);
        }

        public override void UpdateState() {
            base.UpdateState();

            bool isGameTimeOver = playingGameTimer.IsTimeUp();
            if (isGameTimeOver) {
                ctx.fsm.SwitchState(GameState.Over);
            }

            if (PlayerInput.Instance.IsPauseKeyDown) {
                ctx.fsm.SwitchState(GameState.Pause);
            }
        }
    }
}
