using FSM;
using UnityEngine;

public class FSMBehaviour : MonoBehaviour
{
    public ICurrentStateHasCircleMethod hasCurrentStateCircle;

    private IStateCircleMethod currentState => hasCurrentStateCircle.GetCurrentStateCirlce();

    private void Start() {
        currentState.EnterState();
    }

    private void FixedUpdate() {
        currentState.FixedUpdateState();
    }

    private void Update() {
        currentState.UpdateState();   
    }

    private void OnDisable() {
        currentState.ExitState();
    }

}
