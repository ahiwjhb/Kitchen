using UnityEngine;
using static StoveCounter;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] StoveCounter stoveCounter;

    [SerializeField] ProcessBarUI tryingProcessBarUI;

    [SerializeField] ProcessBarUI overDoingProcessBarUI;

    [SerializeField] GameObject sizzlingParticlesVFX;

    [SerializeField] GameObject stoveVFX;

    private AudioSource fryingAudio;

    private ProcessBarUI currentStateProcessBar;

    private void Awake() {
        currentStateProcessBar = tryingProcessBarUI;
        fryingAudio = GetComponent<AudioSource>();
    }

    private void Start() {
        stoveCounter.OnProcessChange += UpdateProcessBarVisual;
        stoveCounter.FSM.GetStateEvent(StoveState.Idle).OnEnterState += OnEnterIdleState;
        stoveCounter.FSM.GetStateEvent(StoveState.Frying).OnEnterState += OnEnterFryingState;
        stoveCounter.FSM.GetStateEvent(StoveState.OverDoing).OnEnterState += OnEnterOverDoingState;
        stoveCounter.FSM.GetStateEvent(StoveState.Burned).OnEnterState += OnEnterBurned;
    }

    public void UpdateProcessBarVisual(float process) {
        currentStateProcessBar.SetProcess(process);
    }


    private void OnEnterIdleState() {
        StoveVisual(false);
        fryingAudio.enabled = false;
    }

    private void OnEnterFryingState() {
        SwitchProcessBar(tryingProcessBarUI);
        StoveVisual(true);
        fryingAudio.enabled = true;
    }

    private void OnEnterOverDoingState() {
        SwitchProcessBar(overDoingProcessBarUI);
    }

    private void OnEnterBurned() {
        StoveVisual(false);
        fryingAudio.enabled = false;
    }

    private void StoveVisual(bool visiable) {
        currentStateProcessBar.SetVisible(visiable);
        sizzlingParticlesVFX.SetActive(visiable);
        stoveVFX.SetActive(visiable);
    }

    private void SwitchProcessBar(ProcessBarUI processBar) {
        currentStateProcessBar.SetProcess(0);
        currentStateProcessBar.SetVisible(false);
        currentStateProcessBar = processBar;
        currentStateProcessBar.SetVisible(true);
    }
}
