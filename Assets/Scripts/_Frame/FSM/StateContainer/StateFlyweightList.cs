using System;
using System.Collections.Generic;
using System.Reflection;

namespace FSM
{
    public class StateFlyweightList    {
        //private readonly static List<State<StateEnum> stateList;

        //static StateFlyweightList() {
        //    string contextClassName = typeof(ContextClass).FullName;
        //    FieldInfo[] enumFields = typeof(StateEnum).GetFields();
        //    stateList = new List<State<StateEnum, ContextClass>>(enumFields.Length);
        //    for (int i = 1; i < enumFields.Length; ++i) {
        //        string stateClassName = string.Format("{0}+{1}State", contextClassName, enumFields[i].Name);
        //        Type stateClassType = Type.GetType(stateClassName);
        //        State<StateEnum, ContextClass> stateEvent = Activator.CreateInstance(stateClassType) as State<StateEnum, ContextClass>;
        //        stateList.Add(stateEvent);
        //    }
        //}

        //public IStateMethod<StateEnum, ContextClass> GetStateMethod(StateEnum stateEnum) {
        //    return stateList[stateEnum.GetHashCode()];
        //}

        //public IStateEvent GetStateEvent(StateEnum stateEnum) {
        //    return stateList[stateEnum.GetHashCode()];
        //}dException();
    }
}   
