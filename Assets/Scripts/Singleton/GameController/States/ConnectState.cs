using FSM;
using Unity.Netcode;

public partial class GameController
{
    private class ConnectState : State<GameState, GameController>
    {
        public override GameState Type => GameState.Connect;

        public override void EnterState() {
            base.EnterState();
            NetworkManager.Singleton.OnServerStarted += () => {
                ctx.fsm.SwitchState(GameState.Wait);
            };
        }
    }
}