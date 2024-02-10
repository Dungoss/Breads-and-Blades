using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;

    public float moveSpeed = 4f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
    }

    public void Move()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(horizontal, 0f, vertical).normalized;


        Vector3 velocity = moveSpeed * Time.deltaTime * moveDir;

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = .5f;
        float playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance);

        if (canMove && moveDir.magnitude >= 0.1f)
        {

            float rotationSpeed = 10f;
            Quaternion targetRotation = Quaternion.LookRotation(moveDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);


            Debug.Log(velocity);
            characterController.Move(velocity);
        }
        animator.SetFloat("Speed", velocity.magnitude);
    }

    //Keep coding!!!!!!!!!!!!
}
