using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Playables;

public class Test01 : MonoBehaviour
{
    [ContextMenu("Test")]
    private void T() {
        this.AddComponent<A<int>>();
    }
}


public class A<T> : MonoBehaviour
{
    T a;
}