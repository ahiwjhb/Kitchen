using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlateVisual : MonoBehaviour
{
    [SerializeField] Transform iconUITSM;

    public void OnAddKitchenObject(KitchenObject kitchenObject) {
        GameObject icon = new GameObject("icon");
        icon.AddComponent<Image>().sprite = kitchenObject.KitchenObjectSo.sprite;
        icon.transform.SetParent(iconUITSM);
        icon.transform.localPosition = Vector3.zero;
        icon.transform.localEulerAngles = Vector3.zero;
    }
}
