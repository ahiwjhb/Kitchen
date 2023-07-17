using UnityEngine;
using FSM;
using static StoveCounter;
using Unity.VisualScripting;

public partial class StoveCounter : CanPlacedKitchenObjectCounter, IHasStateMachine<StoveState>
{
    public enum StoveState
    {
        Idle,
        Frying,
        OverDoing,
        Burned
    }

    [SerializeField] FryingFormulaList fryingFormulaList;

    private FryingFormulaList.FryingFormula fryingFormula;

    private FSMachine<StoveState, StoveCounter> fsm;

    public IStateMachineEvent<StoveState> FSM => fsm;

    private void Awake() {
        fsm = new FSMachine<StoveState, StoveCounter>(this, StoveState.Idle);
    }

    private void Start() {
        fsm.EnterState();
    }

    private void FixedUpdate() {
        fsm.FixedUpdateState();
    }

    private void Update() {
        fsm.UpdateState();
    }

    public override void Interact(Player player) {
        if ((player as IPlaceKitchenObject).TryPlace(GetBePlacedKitchenObject())) {
            fsm.SwitchState(StoveState.Idle);
        }
        else if ((this as IPlaceKitchenObject).TryPlace(player.GetBePlacedKitchenObject())) {
            fsm.SwitchState(StoveState.Frying);
        }
    }

    public override bool CanPlaceKitchenObject(KitchenObject kitchenObject) {
        return base.CanPlaceKitchenObject(kitchenObject) && fryingFormulaList.TryGetFormula(kitchenObject, out fryingFormula);
    }
}
