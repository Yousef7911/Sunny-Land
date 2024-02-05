using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class FlyingEnemy : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject player;
    [SerializeField] Transform startPosEnemy;
    SpriteRenderer render; 
     public bool chase;

    private void Start()
    {
        render= GetComponent<SpriteRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (player is null)
            return; //the player dose not exisit
        if (chase == true)
            ChaseTarget();
        else
            ReturnEnemyToSartPos();
        Flip();
    }

    void ChaseTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Flip()
    {
        if (transform.position.x < player.transform.position.x)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);
    }

    void ReturnEnemyToSartPos()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPosEnemy.position, speed * Time.deltaTime);
        Flip();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.color = Color.red;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            render.color = Color.white;
        }
    }
}
