using System;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using static CuttingCounter;

public class CuttingCounterSensorial : MonoBehaviour
{
    [SerializeField] CuttingCounter cuttingCounter;

    [SerializeField] AudioClip cutSound;

    private static readonly int CUT_TRIGGER = Animator.StringToHash("Cut");

    private Animator animator;

    private ProcessBarUI cuttingProcessBarUI;

    private AudioSource audioSource;

    private void Awake() {
        animator = GetComponent<Animator>();
        cuttingProcessBarUI = GetComponentInChildren<ProcessBarUI>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        cuttingProcessBarUI.SetVisible(false);
        cuttingCounter.OnCutNumberChange += CutSensorial;
    }

    private void CutSensorial(object sender, EventArgs args) {
        if (sender is not CuttingCounter || args is not CutEventArgs) return;
;
        CutEventArgs e = args as CutEventArgs;

        CutVFX(e.currentCutNumber, e.targetCutNumber);
        CutSFX(e.currentCutNumber);
    }

    private void CutVFX(int currentCutNumber, int maxCutNumber) {
        if (currentCutNumber != 0) {
            animator.SetTrigger(CUT_TRIGGER);
            cuttingProcessBarUI.SetProcess((float)currentCutNumber / maxCutNumber);
        }
        cuttingProcessBarUI.SetVisible(currentCutNumber > 0 && currentCutNumber < maxCutNumber);
    }

    private void CutSFX(int curentCutNumber) {
        if(curentCutNumber != 0)
            audioSource.PlayOneShot(cutSound);
    }

}
