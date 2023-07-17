using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "KitchenObjectList")]
public class KitchenObjectSet : ScriptableObject
{
    [SerializeField] List<KitchenObjectSO> kitchenObjectArray;

    private HashSet<KitchenObjectSO> kitchenObjectSet;

    private void OnEnable() {
        kitchenObjectSet = new HashSet<KitchenObjectSO>();
        foreach(var kitchenObjectSO in kitchenObjectArray) {
            kitchenObjectSet.Add(kitchenObjectSO);
        }
    }

    public bool HasKitchenObject(KitchenObjectSO kitchenObjectSO) {
        return kitchenObjectSet.Contains(kitchenObjectSO);
    }
}
