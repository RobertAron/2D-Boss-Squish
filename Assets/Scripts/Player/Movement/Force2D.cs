using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force2D : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		Vector3 newPosition = transform.position;
		newPosition.z = 0;
		transform.position = newPosition;
	}
}
