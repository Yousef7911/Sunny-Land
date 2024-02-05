using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
   private Rigidbody2D rigidBody;
    Vector3 gravity = new Vector3(0, -14.8f, 0);
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rigidBody.AddForce(gravity);
    }
}
