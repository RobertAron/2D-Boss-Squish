using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Watching : MonoBehaviour {
	public GameObject watchie;
	public Vector3 offset;
	
	// Update is called once per frame
	void Update () {
		Vector3 watchieAngle = watchie.transform.position.normalized;
		Vector3 normalDireciton = Vector3.up;
		// float zPostion = Vector3.Angle(normalDireciton,watchieAngle);
		float zPostion = Quaternion.FromToRotation(normalDireciton, watchieAngle).eulerAngles.z;
		transform.rotation = Quaternion.Euler(0,0,zPostion);
	}
}
