using System;

namespace FSM
{
    public interface IStateMethod<StateEnum>: IStateCircleMethod where StateEnum : Enum
    {
        public StateEnum Type { get; }
    }
}
