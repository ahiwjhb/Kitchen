using System;
using System.Collections.Generic;
using System.Reflection;

namespace FSM
{
    public class StateList<StateEnum, ContextClass> : IStateContainer<StateEnum, ContextClass> where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        private List<State<StateEnum, ContextClass>> stateList;

        public StateList(ContextClass context) {
            string contextClassName = typeof(ContextClass).FullName;
            FieldInfo[] enumFields = typeof(StateEnum).GetFields();
            stateList = new List<State<StateEnum, ContextClass>>(enumFields.Length);
            for (int i = 1; i < enumFields.Length; ++i) {
                string stateClassName = string.Format("{0}+{1}State", contextClassName, enumFields[i].Name);
                Type stateClassType = Type.GetType(stateClassName);
                State<StateEnum, ContextClass> state = Activator.CreateInstance(stateClassType) as State<StateEnum, ContextClass>;
                state.Init(context);
                stateList.Add(state);
            }
        }

        public IStateMethod<StateEnum> GetStateMethod(StateEnum stateEnum) {
            return stateList[stateEnum.GetHashCode()];
        }

        public IStateEvent GetStateEvent(StateEnum stateEnum) {
            return stateList[stateEnum.GetHashCode()];
        }
    }
}
