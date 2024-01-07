using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;
    float horizontal;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = new Vector3(1, 1, 1);
        horizontal = Input.GetAxis("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0f, 0f);
        if (horizontal > 0f) {
            animator.SetBool("Move", true);
            transform.localScale = new Vector2(1, 1);
        }
        else if (horizontal < 0f) {
            animator.SetBool("Move", true);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontal == 0f) {
            animator.SetBool("Move", false);
        }
    }
}
