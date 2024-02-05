using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    [SerializeField] float speedBeetle;
    [SerializeField] GameObject player;
    [SerializeField] Transform startPoint;
    public bool isChase;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player is null)
            return;
         if( isChase )
            chaseTarget();
         else
            returnToStartPoint();
        flip();
    }

    private void chaseTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speedBeetle * Time.deltaTime);
    }

    private void flip()
    {
        if (player.transform.position.x > transform.position.x)
            transform.localScale = new Vector2(-1, 1);
        else
            transform.localScale = new Vector2(1, 1);

    }

    void returnToStartPoint()
    {
        transform.position = Vector3.MoveTowards(transform.position, startPoint.position, speedBeetle * Time.deltaTime);
    }
}
