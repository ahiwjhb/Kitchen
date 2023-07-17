using FSM;
using UnityEngine.InputSystem;

public partial class GameController
{ 
    private class OverState : State<GameState, GameController>
    {
        public override GameState Type => GameState.Over;

        public override void EnterState() {
            base.EnterState();
            PlayerInput.Instance.Disable();
        }
    }
}
