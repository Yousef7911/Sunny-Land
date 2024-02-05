using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CahseContraol : MonoBehaviour
{
    [SerializeField] FlyingEnemy[] enemies;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            foreach (FlyingEnemy enemy in enemies)
            {
                enemy.chase = true;
                enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.green;
            }
               
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (FlyingEnemy enemy in enemies)
            {
                enemy.chase = false;
                enemy.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            }

        }
    }
}
