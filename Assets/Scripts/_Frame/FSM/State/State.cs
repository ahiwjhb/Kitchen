using System;
using UnityEngine;

namespace FSM 
{
    public abstract class State<StateEnum, ContextClass> : IStateMethod<StateEnum>, IStateEvent where StateEnum : Enum where ContextClass : IHasStateMachine<StateEnum>
    {
        public event Action OnEnterState;

        public event Action OnFixedUpdate;

        public event Action OnUpdate;

        public event Action OnExitState;

        protected ContextClass ctx;

        public abstract StateEnum Type { get; }

        public virtual void EnterState() {
            OnEnterState?.Invoke();
        }

        public virtual void FixedUpdateState() {
            OnFixedUpdate?.Invoke();
        }

        public virtual void UpdateState() {
            OnUpdate?.Invoke();
        }

        public virtual void ExitState() {
            OnExitState?.Invoke();
        }

        public void Init(ContextClass ctx) {
            this.ctx = ctx;
        }
    }
}
