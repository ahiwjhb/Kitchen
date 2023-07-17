using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSo;

    public KitchenObjectSO KitchenObjectSo => kitchenObjectSo;

    public IPlaceKitchenObject CurrentPlace { get; set; }

    public static KitchenObject Creat(KitchenObjectSO kitchenObjectSO, IPlaceKitchenObject initPlace) {
        if (kitchenObjectSO == null || initPlace == null) return null;

        if (initPlace.GetBePlacedKitchenObject() != null) {
            initPlace.GetBePlacedKitchenObject().DestroySelf();
        }

        KitchenObject newKitchenObject = Instantiate(kitchenObjectSO.perfab).GetComponent<KitchenObject>();
        newKitchenObject.CurrentPlace = initPlace;
        initPlace.Place(newKitchenObject);

        return newKitchenObject;
    }


    public void SetTransfromParent(Transform partent) {
        transform.SetParent(partent);
        transform.localPosition = Vector3.zero;
        transform.localEulerAngles = Vector3.zero;
    }

    public void DestroySelf(){
        CurrentPlace.SetPlaceKitchenObject(null);
        Destroy(gameObject);
    }
}
