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

        Debug.Log(moveDir);
        
        if(moveDir.magnitude >= 0.1f)
        {
            transform.rotation = Quaternion.LookRotation(moveDir);
            characterController.Move(velocity);
        }
        animator.SetFloat("Speed", velocity.magnitude);
    }
}
