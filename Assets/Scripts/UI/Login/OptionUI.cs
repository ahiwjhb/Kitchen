using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static PlayerInput;

public class OptionUI : UIWindow
{
    [SerializeField] Button volumeButton;

    [SerializeField] Button moveUpRebindButton;

    [SerializeField] Button moveDownRebindButton;

    [SerializeField] Button moveLeftRebindButton;

    [SerializeField] Button moveRightRebindButton;

    [SerializeField] Button interactRebindButton;

    [SerializeField] Button secondaryInteractRebindButton;

    [SerializeField] Button exitButton;

    [SerializeField] Interval volumeInterval;

    [SerializeField] ListenerKeyUI listenerKeyUI;

    private TMP_Text volmeText;

    private int currentVolume = 1;

    protected override void Awake() {
        base.Awake();
        volmeText = volumeButton.GetComponentInChildren<TMP_Text>();
    }

    private void Start() {
        volumeButton.onClick.AddListener(OnVolumeButtonDown);
        volmeText.text = "VOLUME: " + currentVolume.ToString();
        UpdateRebindButtonTexts();

        moveUpRebindButton.onClick.AddListener(()=> RebindingKeyVisual(BindingKey.MoveUp));
        moveDownRebindButton.onClick.AddListener(() => RebindingKeyVisual(BindingKey.MoveDonw));
        moveLeftRebindButton.onClick.AddListener(() => RebindingKeyVisual(BindingKey.MoveLeft));
        moveRightRebindButton.onClick.AddListener(() => RebindingKeyVisual(BindingKey.MoveRight));
        interactRebindButton.onClick.AddListener(() => RebindingKeyVisual(BindingKey.Interact));
        secondaryInteractRebindButton.onClick.AddListener(() => RebindingKeyVisual(BindingKey.SecondaryInteract));

        exitButton.onClick.AddListener(() => SetVisible(false));
    }

    private void OnVolumeButtonDown() {
        currentVolume++;
        if(currentVolume > volumeInterval.rightEndPoint) {
            currentVolume = (int)volumeInterval.leftEndPoint;
        }
        volmeText.text = "VOLUME: " + currentVolume.ToString();
    }

    private void UpdateRebindButtonTexts() {
        Func<BindingKey, string> BindingKeyToString = PlayerInput.Instance.GetBindingKey;
        SetButtonText(moveUpRebindButton, BindingKeyToString(BindingKey.MoveUp));
        SetButtonText(moveDownRebindButton, BindingKeyToString(BindingKey.MoveDonw));
        SetButtonText(moveLeftRebindButton, BindingKeyToString(BindingKey.MoveLeft));
        SetButtonText(moveRightRebindButton, BindingKeyToString(BindingKey.MoveRight));
        SetButtonText(interactRebindButton, BindingKeyToString(BindingKey.Interact));
        SetButtonText(secondaryInteractRebindButton, BindingKeyToString(BindingKey.SecondaryInteract));
    }

    private void SetButtonText(Button btn, string text) {
        TMP_Text btnText = btn.GetComponentInChildren<TMP_Text>();
        btnText.text = text;
    }

    private void RebindingKeyVisual(BindingKey rebindingKey) {
        listenerKeyUI.SetVisible(true);
        PlayerInput.Instance.Rebinding(rebindingKey, () => {
            UpdateRebindButtonTexts();
            listenerKeyUI.SetVisible(false);
        });
    }
}
