using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject player;
  //  [SerializeField] GameObject enemy;

    private void Update()
    {

        Vector3 vectorBetweenPlayerAndEnemy = player.transform.position - transform.position;
        transform.position = transform.position + vectorBetweenPlayerAndEnemy.normalized * Time.deltaTime * 2;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Debug.Log("Ouch , you hit me !");
            this.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }

    }
}
