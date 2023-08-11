using FSM;
using System;
using UnityEngine;

public interface IStateMechine<StateEnum, ContextClass> : IHasCurrentState, ICanStateChange<StateEnum>, IStateMechinePublic<StateEnum> where StateEnum : Enum where ContextClass : MonoBehaviour, IHasStateMachine<StateEnum>
{

}
