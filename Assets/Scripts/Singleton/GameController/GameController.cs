using FSM;
using UnityEngine;
using static GameController;

public partial class GameController : MonoSingleton<GameController>, IHasStateMachine<GameState>
{
    public enum GameState {
        Connect,
        Wait,
        Playing,
        Pause,
        Over
    }

    [SerializeField] float playGameWaitTimeSecond = 5;

    [SerializeField] float playGameTimeSecond = 60;

    private IStateMechine<GameState, GameController> fsm;


    protected override void Awake() {
        base.Awake();
        fsm = new FSMachine<GameState, GameController>(this, GameState.Wait);
    }

    public float PlayGameWaitTimeSecond => playGameWaitTimeSecond;

    public float PlayGameTimeSecond => playGameTimeSecond;

    public IStateMechinePublic<GameState> FSM => fsm;

    //public static void Debug(string msg) {
    //    UnityEngine.Debug.Log(msg);
    //}
}
