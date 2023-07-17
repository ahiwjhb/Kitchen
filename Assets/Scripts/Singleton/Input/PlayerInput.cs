using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoSingleton<PlayerInput>
{
    public event Action<InputAction.CallbackContext> OnClickInteractKey {
        add => inputActions.GamePlayInput.Interact.performed += value;
        remove => inputActions.GamePlayInput.Interact.performed -= value;
    }

    public event Action<InputAction.CallbackContext> OnClickSecondaryInteractKey {
        add => inputActions.GamePlayInput.SecondaryInteract.performed += value;
        remove => inputActions.GamePlayInput.SecondaryInteract.performed -= value;
    }

    private PlayerInputAction inputActions;

    public bool IsPauseKeyDown => inputActions.GamePlayInput.Pause.WasPerformedThisFrame();

    protected override void Awake() {
        base.Awake();
        inputActions = new PlayerInputAction();
    }

    private void Start() {
        inputActions.GamePlayInput.Pause.Enable();
    }

    public void Enable() {
        inputActions.GamePlayInput.Move.Enable();
        inputActions.GamePlayInput.Interact.Enable();
        inputActions.GamePlayInput.SecondaryInteract.Enable();
    }

    public void Disable() {
        inputActions.GamePlayInput.Move.Disable();
        inputActions.GamePlayInput.Interact.Disable();
        inputActions.GamePlayInput.SecondaryInteract.Disable();
    }

    public Vector2 GetInputVectorNormalized()  {
        return inputActions.GamePlayInput.Move.ReadValue<Vector2>();
    }
}
