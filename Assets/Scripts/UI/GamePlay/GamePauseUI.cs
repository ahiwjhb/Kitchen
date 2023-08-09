using FSM;
using static GameController;

public class GamePauseUI : UIWindow
{
    protected override void Awake() {
        base.Awake();
        IStateEvent pauseStateEvent = GameController.Instance.FSM.GetStateEvent(GameState.Pause);
        pauseStateEvent.OnEnterState += () => SetVisible(true);
        pauseStateEvent.OnExitState += () => SetVisible(false);
    }
}
