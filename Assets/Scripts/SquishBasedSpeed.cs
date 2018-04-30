using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishBasedSpeed : MonoBehaviour {
	

	public float velocityWeight=1;

	private Transform tf;
	private Rigidbody rb;	

	void Start()
	{
		tf = GetComponent<Transform>();
		rb = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 currentVelocity = rb.velocity;
		tf.rotation = Quaternion.Euler(0,0,Mathf.Atan2(currentVelocity.y,currentVelocity.x)*Mathf.Rad2Deg);
		float stretch =  Mathf.Abs(currentVelocity.magnitude)*velocityWeight+1;
		tf.localScale = new Vector3(stretch,1,1);
	}
}
