using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int IS_WALKING = Animator.StringToHash("IsWalking");

    private Player player;

    private Animator animator;

    private void Awake() {
        player = GetComponent<Player>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_WALKING, player.IsWalking);
    }
}
