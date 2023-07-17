using FSM;
using UnityEngine;

public partial class GameController
{
    private class PauseState : InterruptState<GameState, GameController>
    {
        public override GameState Type => GameState.Pause;

        public override void EnterState() {
            base.EnterState();
            PlayerInput.Instance.Disable();
            Time.timeScale = 0;
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
            if (PlayerInput.Instance.IsPauseKeyDown) {
                Back();
            }
        }

        public override void ExitState() {
            base.ExitState();
            PlayerInput.Instance.Enable();
            Time.timeScale = 1;
        }
    }
}
