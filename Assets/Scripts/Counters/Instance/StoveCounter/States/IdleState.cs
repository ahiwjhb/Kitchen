using FSM;
public partial class StoveCounter
{
    private class IdleState : State<StoveState, StoveCounter>
    {
        public override StoveState Type => StoveState.Idle;
    }
}

