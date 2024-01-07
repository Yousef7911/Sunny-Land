using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] float jumpForce;
    private bool isGrounded ;
    private Animator animator;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
     void Update()
     {
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            jump();
        }
        if(!isGrounded ) {
            animator.SetFloat("JumpFall", rigidbody.velocity.y);
        }
        if(Input.GetKeyDown(KeyCode.Z) && isGrounded) {
            animator.SetBool("Crouch", true);
        }
        else if (Input.GetKeyUp(KeyCode.Z) && isGrounded) {
            animator.SetBool("Crouch", false);
        }
    }
     void jump()
    {
        rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            isGrounded = true;
            animator.SetFloat("JumpFall", 0);
        }
    }
}
