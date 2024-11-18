using Unity.Netcode;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class NetBehaviourSingleton<T> : NetworkBehaviour where T : NetBehaviourSingleton<T>
{
    static private T instance;

    static public T Instance => instance;

    protected virtual void Awake() {
        if (instance == null) {
            instance = this as T;
        }
        else if (instance != this) {
#if UNITY_EDITOR
            Debug.LogFormat("当前场景有重复的单例 {0} ", this.name);
#endif
            Destroy(gameObject);
        }
    }
}

