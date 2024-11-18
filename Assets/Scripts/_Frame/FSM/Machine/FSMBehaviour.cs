using FSM;
using UnityEngine;

public class FSMBehaviour : MonoBehaviour
{
    public IHasCurrentState mandatorFSM;

    private IStateCircleMethod currentState => mandatorFSM.GetCurrentState();

    private void Start() {
        currentState.EnterState();
    }

    private void FixedUpdate() {
        currentState.FixedUpdateState();
    }

    private void Update() {
        currentState.UpdateState();   
    }

    private void OnDestroy() {
        currentState.ExitState();
    }
}
