using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    [SerializeField] float jumpForce;
    private bool isGrounded ;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
        {
            jump();
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
            Debug.Log("Jump");
        }
    }

}
