using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed;

    [SerializeField] GameObject Enemy;

    [SerializeField] GameObject player;
    [SerializeField] GameObject enemy;

    Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        #region Movement
        // transform.position = new Vector3(1, 1, 1);
       float horizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(horizontal * speed * Time.deltaTime, 0f, 0f);

        if (horizontal > 0)
        {
            transform.localScale = new Vector2(1, 1);
           // Debug.Log("Right");
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-1, 1);
           // Debug.Log("Left");
        }
        if (horizontal == 0)
            Debug.Log("Idel");
        #endregion

        #region Secret
        //float lerp = Mathf.PingPong(Time.time, 2);
        //Enemy.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.blue, Color.magenta, lerp);


        Vector3 vectorBetweenPlayerAndEnemy = player.transform.position - enemy.transform.position;
        //if (enemy.GetComponent<Rigidbody2D>().velocity.x < 0.01f)
        //    enemy.transform.localScale = new Vector2(-1, 1);
        if (transform.position.x > enemy.transform.position.x)
            enemy.transform.localScale = new Vector2(-1, 1);
        else
            enemy.transform.localScale = new Vector2(1, 1);

        enemy.transform.position = enemy.transform.position + vectorBetweenPlayerAndEnemy.normalized * Time.deltaTime * 2;

        //enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, player.transform.position, Time.deltaTime * 2); 
        #endregion
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy")
        {
            Debug.Log("Ouch , You Hit me !");
           
        }
    }
}
