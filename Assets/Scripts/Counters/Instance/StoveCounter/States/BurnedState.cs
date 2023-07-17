using FSM;

public partial class StoveCounter
{
    private class BurnedState : State<StoveState, StoveCounter>
    {
        public override StoveState Type => StoveState.Burned;
    }
}