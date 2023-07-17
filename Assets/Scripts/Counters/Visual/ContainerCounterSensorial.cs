using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerCounterSensorial : MonoBehaviour
{
    [SerializeField] ContainerCounter containerCounter;

    [SerializeField] AudioClip interactSound;

    private readonly int OPEN_TRIGGER = Animator.StringToHash("OpenClose");

    private Animator animator;

    private AudioSource audioSource;

    private void Awake() {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        containerCounter.OnInteract += InteractVFX;
        containerCounter.OnInteract += InteractSFX;
    }


    private void InteractVFX(object sender, EventArgs e) {
        animator.SetTrigger(OPEN_TRIGGER);
    }

    private void InteractSFX(object sender, EventArgs e) {
        audioSource.PlayOneShot(interactSound);
    }
}
