using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Counter : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject selectedVFX;

    public abstract void Interact(Player player);

    public void ShowSelectedVFX() {
        selectedVFX.SetActive(true);
    }

    public void HideSelectedVFX() {
        selectedVFX.SetActive(false);
    }
}
