using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithBoat : MonoBehaviour
{

	Rigidbody rb;

	CharacterController cc;

	void Start()
    {
		rb = GetComponent<Rigidbody>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			cc = other.GetComponent<CharacterController>();
		}

	}
	private void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player")
		{
			cc.Move(rb.velocity * Time.deltaTime);
		}
	}

}
