using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Player : MonoSingleton<Player>, IPlaceKitchenObject
{
    [SerializeField] Transform holdingObjectTransfrom;

    [SerializeField] float interactDistance = 0.5f;

    [SerializeField] LayerMask interactLayer;

    public event EventHandler OnPlayerPickUp;

    public event EventHandler OnPlayerDropDown;

    private Movement movement;

    private KitchenObject bePlacedKitchenObject;

    private IInteractable selectedInteractObject;

    protected override void Awake() {
        base.Awake();
        movement = GetComponent<Movement>();
    }

    private void Start() {
        PlayerInput.Instance.OnClickInteractKey += InteractWithObject;
        PlayerInput.Instance.OnClickSecondaryInteractKey += SecondaryInteractWithObject;
    }

    private void FixedUpdate() {
        HandleMovenet();
        HandleSelectInteractObject();
    }

    public bool IsWalking => movement.IsMoving;

    public void Place(KitchenObject kitchenObject) {
        kitchenObject.CurrentPlace.SetPlaceKitchenObject(null);
        kitchenObject.CurrentPlace = this;
        kitchenObject.SetTransfromParent(holdingObjectTransfrom);
        SetPlaceKitchenObject(kitchenObject);
    }

    public bool CanPlaceKitchenObject(KitchenObject kitchenObject) {
        return GetBePlacedKitchenObject() == null;
    }

    public KitchenObject GetBePlacedKitchenObject() {
        return bePlacedKitchenObject;
    }

    public void SetPlaceKitchenObject(KitchenObject kitchenObject) {
        if (kitchenObject != null) {
            OnPlayerPickUp?.Invoke(this, EventArgs.Empty);
        }
        else {
            OnPlayerDropDown?.Invoke(this, EventArgs.Empty);
        }
        bePlacedKitchenObject = kitchenObject;
    }

    private void HandleMovenet() {
        Vector2 inputVector = PlayerInput.Instance.GetInputVectorNormalized();
        movement.MoveDirection = new Vector3(inputVector.x, 0, inputVector.y);
    }

    private void HandleSelectInteractObject() {
        IInteractable lastSelectInteractIbject = selectedInteractObject;
        selectedInteractObject = null;
        if(Physics.Raycast(transform.position, transform.forward, out var raycastHit, interactDistance, interactLayer)) {
            if (raycastHit.transform.TryGetComponent<IInteractable>(out selectedInteractObject)) {
                selectedInteractObject.ShowSelectedVFX();
            }
        }
        if (selectedInteractObject != lastSelectInteractIbject) lastSelectInteractIbject?.HideSelectedVFX();
    }

    private void InteractWithObject(InputAction.CallbackContext context) {
        selectedInteractObject?.Interact(this);
    }

    private void SecondaryInteractWithObject(InputAction.CallbackContext context) {
        (selectedInteractObject as ISecondaryInteractable)?.SecondaryInteract();
    }
}
