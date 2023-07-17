using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : KitchenObject, IPlaceKitchenObject
{
    [SerializeField] KitchenObjectSet canPlaceKitchenObjects;

    [SerializeField] int maxCapacity = 8;

    private PlateVisual plateVisual;

    private List<KitchenObjectSO> placedKitchenObjects;

    public List<KitchenObjectSO> PlacedKitchenObjects => placedKitchenObjects;

    private void Awake() {
        plateVisual = GetComponentInChildren<PlateVisual>();
        placedKitchenObjects = new List<KitchenObjectSO>();
    }

    void IPlaceKitchenObject.Place(KitchenObject kitchenObject) {
        plateVisual.OnAddKitchenObject(kitchenObject);
        placedKitchenObjects.Add(kitchenObject.KitchenObjectSo);
        kitchenObject.DestroySelf();
    }

    bool IPlaceKitchenObject.CanPlaceKitchenObject(KitchenObject kitchenObject) {
        KitchenObjectSO kitchenObjectSO = kitchenObject.KitchenObjectSo;
        return canPlaceKitchenObjects.HasKitchenObject(kitchenObjectSO) && placedKitchenObjects.Count < maxCapacity;
    }

    KitchenObject IPlaceKitchenObject.GetBePlacedKitchenObject() {
        return null;
    }

    void IPlaceKitchenObject.SetPlaceKitchenObject(KitchenObject kitchenObject) { }
}
