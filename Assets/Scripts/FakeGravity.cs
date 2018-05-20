using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeGravity : MonoBehaviour {

	Vector3 gravity = new Vector3(0,0,0);
	Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		rb.velocity+= gravity;
	}
	public void setGravity(Vector3 gravity)
	{
		this.gravity = gravity.normalized*2;
		Debug.Log("NEW SET" + gravity);
	}
}
