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

    private FSMachine<GameState, GameController> fsm;


    protected override void Awake() {
        base.Awake();
        fsm = new FSMachine<GameState, GameController>(this, GameState.Wait);
    }

    private void Start() {
        fsm.EnterState();
    }

    private void FixedUpdate() {
        fsm.UpdateState();
    }

    private void Update() {
        fsm.FixedUpdateState();
    }

    public float PlayGameWaitTimeSecond => playGameWaitTimeSecond;

    public float PlayGameTimeSecond => playGameTimeSecond;

    public IStateMachineEvent<GameState> FSM => fsm;

    public void Debug(string msg) {
        UnityEngine.Debug.Log(msg);
    }
}
