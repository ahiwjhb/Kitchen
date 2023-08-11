using System;
using Unity.VisualScripting;
using UnityEngine;

namespace FSM
{
    public class FSMachine<StateEnum, ContextClass> : IStateMechine<StateEnum, ContextClass> where StateEnum : Enum where ContextClass : MonoBehaviour, IHasStateMachine<StateEnum>
    {
        public event Action<StateEnum> OnStateChange;

        private IStateMethod<StateEnum> currentState;

        private IStateContainer<StateEnum, ContextClass> stateContainer;


        public FSMachine(ContextClass contextClass, StateEnum defaultState) {
            stateContainer = new StateList<StateEnum, ContextClass>(contextClass);
            currentState = stateContainer.GetStateMethod(defaultState);
            contextClass.AddComponent<FSMBehaviour>().mandatorFSM = this;
        }

        public StateEnum CurrentStateType => currentState.Type;


        public void SwitchState(StateEnum stateEnum) {
            OnStateChange?.Invoke(stateEnum);
            IStateMethod<StateEnum> newState = stateContainer.GetStateMethod(stateEnum);
            if (newState is InterruptState<StateEnum, ContextClass>) {
                newState.EnterState();
                currentState = newState;
            }
            else {
                (currentState as InterruptState<StateEnum, ContextClass>)?.StateBack();
                currentState.ExitState();
                currentState = newState;
                currentState.EnterState();
            }
        }

        public IStateEvent GetStateEvent(StateEnum stateEnum) {
            return stateContainer.GetStateEvent(stateEnum);
        }

        public void SetCurrentState(StateEnum stateEnum) {
            currentState = stateContainer.GetStateMethod(stateEnum);
        }

        public IStateCircleMethod GetCurrentState() {
            return currentState;
        }
    }
}