using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : DontDestoryMonoSingleton<PlayerInput>
{
    public enum BindingKey {
        MoveUp,
        MoveDonw,
        MoveLeft,
        MoveRight,
        Interact,
        SecondaryInteract
    }

    public event Action<InputAction.CallbackContext> OnClickInteractKey {
        add => GamePlayInput.Interact.performed += value;
        remove => GamePlayInput.Interact.performed -= value;
    }

    public event Action<InputAction.CallbackContext> OnClickSecondaryInteractKey {
        add => GamePlayInput.SecondaryInteract.performed += value;
        remove => GamePlayInput.SecondaryInteract.performed -= value;
    }

    private PlayerInputAction inputActions;

    public PlayerInputAction.GamePlayInputActions GamePlayInput => inputActions.GamePlayInput;

    public bool IsPauseKeyDown => inputActions.GamePlayInput.Pause.WasPerformedThisFrame();

    public bool inputEnable;

    protected override void Awake() {
        base.Awake();
        inputActions = new PlayerInputAction();
    }

    private void Start() {
        Disable();
        GamePlayInput.Pause.Enable();
    }

    public void Enable() {
        GamePlayInput.Move.Enable();
        GamePlayInput.Interact.Enable();
        GamePlayInput.SecondaryInteract.Enable();
        inputEnable = true;
    }

    public void Disable() {
        GamePlayInput.Move.Disable();
        GamePlayInput.Interact.Disable();
        GamePlayInput.SecondaryInteract.Disable();
        inputEnable = false;
    }

    public Vector2 GetInputVectorNormalized()  {
        return inputActions.GamePlayInput.Move.ReadValue<Vector2>();
    }

    public string GetBindingKeyText(BindingKey bingdingKey) {
        var bindingInfo = GetBindingInfo(bingdingKey);
        var inputAction = bindingInfo.Item1;
        var bindingIndex = bindingInfo.Item2;
        return inputAction.bindings[bindingIndex].ToDisplayString();
    }

    public void Rebinding(BindingKey bingdingKey, Action completed = null) {
        var bindingInfo = GetBindingInfo(bingdingKey);
        var inputAction = bindingInfo.Item1;
        var bindingIndex = bindingInfo.Item2;

        var rebindOperator = inputAction.PerformInteractiveRebinding(bindingIndex);
        rebindOperator.WithCancelingThrough("<keyboard>/escape");
        rebindOperator.WithControlsExcluding("Mouse");

        rebindOperator.OnCancel((op) => {
            completed?.Invoke();
            op.Dispose();
        });

        rebindOperator.OnComplete((op) => {
            completed?.Invoke();
            op.Dispose();
        });

        rebindOperator.Start();
    }

    private Tuple<InputAction, int> GetBindingInfo(BindingKey bingdingKey) {
        return bingdingKey switch {
            BindingKey.MoveUp => new(GamePlayInput.Move, 1),
            BindingKey.MoveDonw => new (GamePlayInput.Move, 2),
            BindingKey.MoveLeft => new(GamePlayInput.Move, 3),
            BindingKey.MoveRight => new(GamePlayInput.Move, 4),
            BindingKey.Interact => new(GamePlayInput.Interact, 0),
            BindingKey.SecondaryInteract => new(GamePlayInput.SecondaryInteract, 0),
            _ => default,
        };
    }
}
