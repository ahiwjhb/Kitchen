using System;
using UnityEngine;

public class PlayerSensorial : MonoBehaviour
{
    [SerializeField] AudioClip pickUpSound;

    [SerializeField] AudioClip dropDownSound;

    private AudioSource audioSource;

    private Player player;

    private void Awake() {
        player = GetComponent<Player>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start() {
        player.OnPlayerPickUp += PickUpSFX;
        player.OnPlayerDropDown += DropDownSFX;
    }

    private void PickUpSFX(object sender, EventArgs e) {
        audioSource.PlayOneShot(pickUpSound);
    }

    private void DropDownSFX(object sender, EventArgs e) {
        audioSource.PlayOneShot(dropDownSound);
    }
}
