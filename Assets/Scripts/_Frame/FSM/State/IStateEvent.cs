using System;

namespace FSM
{
    /// <summary>
    /// ����״̬����Awake������ɣ���Ҫ��Start����
    /// </summary>
    public interface IStateEvent
    {
        public event Action OnEnterState;

        public event Action OnFixedUpdate;

        public event Action OnUpdate;

        public event Action OnExitState;
    }
}

