using System;

namespace FSM
{
    /// <summary>
    /// 订阅状态请在Awake里面完成，不要在Start里面
    /// </summary>
    public interface IStateEvent
    {
        public event Action OnEnterState;

        public event Action OnFixedUpdate;

        public event Action OnUpdate;

        public event Action OnExitState;
    }
}

