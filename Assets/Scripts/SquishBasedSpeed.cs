using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishBasedSpeed : MonoBehaviour {
	

	public float velocityWeight=1;

	private Transform transform;
	private Rigidbody rigidbody;	

	void Start()
	{
		transform = GetComponent<Transform>();
		rigidbody = GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 currentVelocity = rigidbody.velocity;
		transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(currentVelocity.y,currentVelocity.x)*Mathf.Rad2Deg);
		float stretch =  Mathf.Abs(currentVelocity.magnitude)*velocityWeight+1;
		transform.localScale = new Vector3(stretch,1,1);
	}
}
