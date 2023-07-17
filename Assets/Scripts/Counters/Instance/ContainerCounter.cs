using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounter : Counter
{
    [SerializeField] KitchenObjectSO spawnKitchenObject;

    public event EventHandler OnInteract;

    public override void Interact(Player player) {
        if (player.GetBePlacedKitchenObject() == null) {
            OnInteract?.Invoke(this, EventArgs.Empty);
            KitchenObject.Creat(spawnKitchenObject, player);
        }
    }
}
