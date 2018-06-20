using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotateTowardsPlayer : MonoBehaviour {

	public float turnSpeed=1;
	public Transform target;
	private void FixedUpdate() {
		Vector3 targetVector = (target.position - transform.position).normalized;
		float angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, q, Time.deltaTime * turnSpeed);
	}
}
