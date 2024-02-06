using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlChase : MonoBehaviour
{
   [SerializeField] ChasePlayer[] beetles;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            foreach(ChasePlayer beetle in beetles)
            {
                beetle.isChase = true;
                beetle.gameObject.GetComponent<SpriteRenderer>().color  = Color.red;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            foreach (ChasePlayer beetle in beetles)
            {
                beetle.isChase = false;
                beetle.gameObject.GetComponent<SpriteRenderer>().color = Color.white;

            }
        }
    }
}
