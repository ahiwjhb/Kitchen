using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KitchenObjectSO")]
public class KitchenObjectSO : ScriptableObject
{
    public Sprite sprite;

    public string objectName;

    public GameObject perfab;
}
