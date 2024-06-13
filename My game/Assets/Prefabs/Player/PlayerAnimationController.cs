using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private bool playAnimJump;
    private Rigidbody2D rb;
    private MoveController moveController;
    
   
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        moveController = GetComponent<MoveController>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("yVelocity", rb.velocity.y);
        if (!moveController.CanJump)
            animator.SetTrigger("Jump");
        else if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && moveController.CanJump)
            animator.SetTrigger("Run");
        else if ((Mathf.Abs(rb.velocity.y) < 0.1f) && moveController.CanJump)
            animator.SetTrigger("Idle");
    }
}
