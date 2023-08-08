using FSM;
using UnityEngine;
using static GameController;

public partial class GameController : MonoSingleton<GameController>, IHasStateMachine<GameState>
{
    public enum GameState {
        Wait,
        Playing,
        Pause,
        Over
    }

    [SerializeField] float playGameWaitTimeSecond = 5;

    [SerializeField] float playGameTimeSecond = 60;

    private ICanStateChange<GameState> fsm;


    protected override void Awake() {
        base.Awake();
        fsm = new FSMachine<GameState, GameController>(this, GameState.Wait);
    }

    public float PlayGameWaitTimeSecond => playGameWaitTimeSecond;

    public float PlayGameTimeSecond => playGameTimeSecond;

    public IFSMPublic<GameState> FSM => fsm as IFSMPublic<GameState>;

    public static void Debug(string msg) {
        UnityEngine.Debug.Log(msg);
    }
}
