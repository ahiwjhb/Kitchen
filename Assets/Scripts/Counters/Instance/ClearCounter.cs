public class ClearCounter : CanPlacedKitchenObjectCounter
{
    public override void Interact(Player player) {
        if (!(player as IPlaceKitchenObject).TryPlace(GetBePlacedKitchenObject())) {
            (this as IPlaceKitchenObject).TryPlace(player.GetBePlacedKitchenObject());
        }
    }
}
