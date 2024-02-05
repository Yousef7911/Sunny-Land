using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpWithGravity : MonoBehaviour
{
	private new Rigidbody2D rigidbody;

	private float vervelocity;
	[SerializeField] private float gravity = 14.0f;
	[SerializeField] private float jumpForce = 10.0f;
	public bool isGrounded;
	public float maxDistanceFromGround = 10f;
	public LayerMask groundMask;

	private void Start()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		isGrounded = Physics.CheckSphere(transform.position, maxDistanceFromGround, groundMask);
		if (isGrounded)
		{
			vervelocity = -gravity * Time.deltaTime;
			if (Input.GetButtonDown("Jump"))
			{
				vervelocity = jumpForce;
			}
		}
		else
		{
			vervelocity -= gravity * Time.deltaTime;
		}

		Vector3 move = new Vector3(0, vervelocity, 0);
		rigidbody.AddForce(move * Time.deltaTime);
	}
}