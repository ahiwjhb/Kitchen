using Unity.Netcode;
using Unity.Netcode.Components;
using UnityEngine;

public class PlayerAnimator : NetworkBehaviour
{ 
    private readonly int IS_WALKING = Animator.StringToHash("IsWalking");

    private Player player;

    private Animator animator;

    private void Awake() {
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        if (IsOwner) {
            animator.SetBool(IS_WALKING, player.IsWalking);
        }
    }

}
