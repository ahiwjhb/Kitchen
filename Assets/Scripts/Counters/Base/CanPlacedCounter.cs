using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CanPlacedKitchenObjectCounter : Counter, IPlaceKitchenObject
{
    [SerializeField] Transform placedKitchenObjectTSM;

    private KitchenObject bePlacedKitchenObject;

    public virtual void Place(KitchenObject kitchenObject) {
        kitchenObject.CurrentPlace.SetPlaceKitchenObject(null);
        kitchenObject.CurrentPlace = this;
        kitchenObject.SetTransfromParent(placedKitchenObjectTSM);
        SetPlaceKitchenObject(kitchenObject);
    }

    public virtual KitchenObject GetBePlacedKitchenObject() {
        return bePlacedKitchenObject;
    }

    public virtual void SetPlaceKitchenObject(KitchenObject kitchenObject) {
        bePlacedKitchenObject = kitchenObject;
    }

    public virtual bool CanPlaceKitchenObject(KitchenObject kitchenObject) {
        return !HasKitchenObject();
    }

    public bool HasKitchenObject() {
        return GetBePlacedKitchenObject() != null;
    }
}
