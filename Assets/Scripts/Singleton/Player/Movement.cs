using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10;

    [SerializeField] float rotateSpeed = 15;

    private Rigidbody rigidbody3D;

    private bool isMoving;

    public bool IsMoving => isMoving;

    public Vector3 MoveDirection { get; set; }

    private void Awake() {
        rigidbody3D = GetComponent<Rigidbody>();
    }

    private void Start() {
        MoveDirection = transform.forward;
    }

    public void Update() {
        isMoving = MoveDirection != Vector3.zero;
        rigidbody3D.velocity = MoveDirection * moveSpeed;
        if(MoveDirection != Vector3.zero)
            transform.forward = Vector3.Slerp(transform.forward, MoveDirection, rotateSpeed * Time.deltaTime);
    }
}
