using System;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

namespace FSM
{
    public class FSMachine<StateEnum, ContextClass> : IStateMachineMethod<StateEnum, ContextClass>, IStateMachineEvent<StateEnum> where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        public event Action<StateEnum> OnStateChange;

        private IStateMethod<StateEnum> currentState;

        private IStateContainer<StateEnum, ContextClass> stateContainer;


        public FSMachine(ContextClass contextClass, StateEnum defaultState) {
            stateContainer = new StateList<StateEnum, ContextClass>(contextClass);
            currentState = stateContainer.GetStateMethod(defaultState);
        }

        public StateEnum CurrentState => currentState.Type;


        public void EnterState() {
            currentState.EnterState();
        }
            
        public void FixedUpdateState() {
            currentState.FixedUpdateState();
        }

        public void UpdateState() {
            currentState.UpdateState();
        }

        public void ExitState() {
            currentState.ExitState();
        }

        public void SwitchState(StateEnum stateEnum) {
            OnStateChange?.Invoke(stateEnum);
            IStateMethod<StateEnum> newState = stateContainer.GetStateMethod(stateEnum);
            if (newState is InterruptState<StateEnum, ContextClass>) {
                newState.EnterState();
                currentState = newState;
            }
            else {
                (currentState as InterruptState<StateEnum, ContextClass>)?.Back();
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

        //private bool IsContextClasStateHasField() {
        //    string agintClassName = typeof(ContextClass).FullName;
        //    FieldInfo[] enumFields = typeof(StateEnum).GetFields();
        //    for (int i = 1; i < enumFields.Length; ++i) {
        //        string stateClassName = string.Format("{0}+{1}State", agintClassName, enumFields[i].Name);
        //        BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        //        bool hasField = Type.GetType(stateClassName).GetFields(bindingFlags).Length > 0;
        //        if (hasField) return true;
        //    }
        //    return false;
        //}
    }
}