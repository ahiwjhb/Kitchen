using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : Counter
{
    public override void Interact(Player player) {
        if(player.GetBePlacedKitchenObject() is Plate) {
            Plate dishContainer = player.GetBePlacedKitchenObject() as Plate;
            DishOrderSender.Instance.DeliveryDishOrder(dishContainer.PlacedKitchenObjects);
            dishContainer.DestroySelf();
        }
    }
}
