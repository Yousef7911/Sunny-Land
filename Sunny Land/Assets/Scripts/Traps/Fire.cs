using System.Collections;
using UnityEngine;
public class Fire : MonoBehaviour {
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float ActivationDelay;
    [SerializeField] private float ActiveTime;
    [SerializeField] private float Damage;
    private bool Triggered;
    private bool Active;
    private bool Load;
    private PlayerController Player;

    private void Awake() {
        animator = GetComponentInParent<Animator>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            if (!Triggered) {
                Load = true;
                StartCoroutine(ActiveFireTrap());
            }
        }
        Player = collision.GetComponent<PlayerController>();
    }

    private void OnTriggerExit2D(Collider2D collision) {
        Player = null;
    }

    private void Update() {
        if (Active && Player != null && Load) {
            Player.TakeDamage(Damage);
            Load = false;
        }
    }

    private IEnumerator ActiveFireTrap() {
        Triggered = true;
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(ActivationDelay);
        spriteRenderer.color = Color.white;
        Active = true;
        animator.SetBool("Active", true);
        yield return new WaitForSeconds(ActiveTime);
        Active = false;
        animator.SetBool("Active", false);
        Triggered = false;
    }
}