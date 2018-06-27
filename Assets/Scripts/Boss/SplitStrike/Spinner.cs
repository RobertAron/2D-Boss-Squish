using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour {

	public float spinSpeed;
	void FixedUpdate () {
		Vector3 currentRotation = transform.rotation.eulerAngles;
		currentRotation.z += spinSpeed;
		transform.rotation = Quaternion.Euler(currentRotation);
	}
}
