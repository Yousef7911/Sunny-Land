using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject player;
    private void Update()
    {
        Vector3 vectorBetweenEnmeyandPlayer = player.transform.position - transform.position;

        if (player.transform.position.x> transform.position.x)
            transform.localScale = new Vector3(-1, 1, 1);
        else
            transform.localScale = new Vector3(1, 1, 1);

        transform.position = transform.position+ vectorBetweenEnmeyandPlayer.normalized*Time.deltaTime ;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("Ouch , You Hit me !");
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
    }
}
