using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private readonly int IS_WALKING = Animator.StringToHash("IsWalking");

    private Animator animator;

    private void Awake() {  
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        animator.SetBool(IS_WALKING, Player.Instance.IsWalking);
    }
}
