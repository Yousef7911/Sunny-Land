using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D rigidbody;
    private Animator animator;
    [SerializeField] float jumpForce;
    private bool isGrounded ;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }
        if (!isGrounded) {
            animator.SetFloat("JumpFall", rigidbody.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded) {
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