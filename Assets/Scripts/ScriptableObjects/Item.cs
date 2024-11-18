using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Item : ScriptableObject
{
    public int id;

    protected virtual void OnEnable() {
        if(id == 0) {
            Debug.Log(name + " id√ª”–∑÷≈‰");
        }
    }
}
