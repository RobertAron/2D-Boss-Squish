using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseOrbMovement : MonoBehaviour {

	public float timeToInitialLocation;
	public float timeToStartDisappear;
	public float spinSpeed = 1f;
	public float timeToDisappear;
	private float timePassed = 0f;
	private Vector3 startingPosition = new Vector3(0,0,0);
	private Vector3 fullLengthPosition = new Vector3(1,0,0);
	private Transform parentTransform;
	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.velocity = new Vector3(1/timeToInitialLocation,0,0);
		parentTransform = transform.parent.transform;
	}

	void FixedUpdate()
	{
		timePassed+=Time.deltaTime;
		Vector3 lastPosition = transform.position;
		//Move From position 0 to Full Length
		if(transform.position.x<fullLengthPosition.x)
		{
			transform.localPosition = Vector3.MoveTowards(startingPosition,fullLengthPosition,timePassed/timeToInitialLocation);
		}

		//Move Around In Circle (Change Parent Rotation)
		//Reduce Scale Size
		//Destroy Self
		Vector3 parentRotation =  parentTransform.rotation.eulerAngles;
		parentRotation.z += spinSpeed;
		parentTransform.rotation =  Quaternion.Euler(parentRotation);
		rb.velocity = (transform.position - lastPosition)/Time.deltaTime;
	}
}
