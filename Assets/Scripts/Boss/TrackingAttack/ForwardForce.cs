using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForwardForce : MonoBehaviour {

	// Use this for initialization
	public float movementSpeed=1;
	Rigidbody rb;
	void Start () {
		rb = GetComponent<Rigidbody>();	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.velocity = transform.right * movementSpeed;
	}
}
