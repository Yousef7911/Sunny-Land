using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    private float Horizontal;
    private Animator animator;

    Rigidbody2D rb;

    private float Health;
    [SerializeField] float StartingHealth;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        Health = StartingHealth;
    }
    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Horizontal * speed * Time.deltaTime, 0f, 0f);

        if (Horizontal > 0)
        {
            animator.SetBool("Move", true);
            transform.localScale = new Vector2(1, 1);
        }
        if (Horizontal < 0)
        {
            animator.SetBool("Move", true);
            transform.localScale = new Vector2(-1, 1);
        }
        if (Horizontal == 0) {
            animator.SetBool("Move", false);
        }
        
    }

    public void TakeDamage(float Damage) {
        Health -= Damage;
        Debug.Log(Health);
        if (Health <= 0) { 
            this.gameObject.SetActive(false);
        }
    }
}