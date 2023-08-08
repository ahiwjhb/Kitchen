using FSM;
using UnityEngine;

public partial class GameController
{
    private class PauseState : InterruptState<GameState, GameController>
    {
        public override GameState Type => GameState.Pause;

        private bool playerInputCache;

        public override void EnterState() {
            base.EnterState();
            playerInputCache = PlayerInput.Instance.inputEnable;
            PlayerInput.Instance.Disable();
            Time.timeScale = 0;
        }

        public override void UpdateState() {
            base.UpdateState();
            if (PlayerInput.Instance.IsPauseKeyDown) {
                Back();
            }
        }

        public override void ExitState() {
            base.ExitState();
            if (playerInputCache)
                PlayerInput.Instance.Enable();
            else
                PlayerInput.Instance.Disable();
            Time.timeScale = 1;
        }
    }
}
