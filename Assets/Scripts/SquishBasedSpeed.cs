using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishBasedSpeed : MonoBehaviour {
	

	public float velocityWeight=1;

	private Transform transform;
	private Rigidbody2D rigidbody2D;	

	void Start()
	{
		transform = GetComponent<Transform>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 currentVelocity = rigidbody2D.velocity;
		transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(currentVelocity.y,currentVelocity.x)*Mathf.Rad2Deg);
		float stretch =  Mathf.Abs(currentVelocity.magnitude)*velocityWeight+1;
		transform.localScale = new Vector3(stretch,1,1);
	}
}
