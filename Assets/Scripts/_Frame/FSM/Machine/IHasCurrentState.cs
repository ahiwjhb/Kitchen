using System;


namespace FSM
{
    public interface IHasCurrentState
    {
        public IStateCircleMethod GetCurrentState();
    }
}
