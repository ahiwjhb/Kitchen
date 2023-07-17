using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 不会被销毁的持久单例类
/// </summary>
/// <typeparam name="T"></typeparam>
public class DontDestoryMonoSingleton<T> : MonoBehaviour where T : DontDestoryMonoSingleton<T>
{
    private static T instance;

    public static T Inst {
        get {
            if(instance == null) {
                instance = new GameObject("new" + typeof(T).Name).AddComponent<T>();
                instance.Awake();
            }
            return instance;
        }
    }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(this);
        }
        else if(instance != this)
        {
        #if UNITY_EDITOR 
            Debug.LogFormat("当前场景有重复的持久单例 {0} ", this.name);
        #endif
            Destroy(gameObject);
        }
    }
}
