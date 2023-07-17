public interface IPlaceKitchenObject
{
    public bool TryPlace(KitchenObject kitchenObject) {
        bool isSuccessful = false;
        if (GetBePlacedKitchenObject() is IPlaceKitchenObject) {
            isSuccessful = (GetBePlacedKitchenObject() as IPlaceKitchenObject).TryPlace(kitchenObject);
        }
        else if (kitchenObject != null && CanPlaceKitchenObject(kitchenObject)) {
            Place(kitchenObject);
            isSuccessful = true;
        }
        return isSuccessful;
    }

    public KitchenObject GetBePlacedKitchenObject();

    public void SetPlaceKitchenObject(KitchenObject kitchenObject);

    public void Place(KitchenObject kitchenObject);

    public bool CanPlaceKitchenObject(KitchenObject kitchenObject);
}
