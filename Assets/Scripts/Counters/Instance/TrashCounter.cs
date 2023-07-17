using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : Counter
{
    private AudioSource trashAudio;

    private void Awake() {
        trashAudio = GetComponent<AudioSource>();
    }

    public override void Interact(Player player) {
        if (player.GetBePlacedKitchenObject() != null) {
            trashAudio.Play();
            player.GetBePlacedKitchenObject().DestroySelf();
        }
    }
} 
