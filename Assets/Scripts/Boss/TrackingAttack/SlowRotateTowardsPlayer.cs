using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowRotateTowardsPlayer : MonoBehaviour {

	public float turnSpeed=2;
	public float trackingDisableTime=2;
	public Transform target;

	private void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	private void OnEnable() {
		StartCoroutine(disableTrackingCountDown());
	}

	private void FixedUpdate() {
		Vector3 targetVector = (target.position - transform.position).normalized;
		float angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.SlerpUnclamped(transform.rotation, q, Time.deltaTime * turnSpeed);
	}
	IEnumerator disableTrackingCountDown(){
		float totalTime;
		for(totalTime=0;totalTime<trackingDisableTime;totalTime+=Time.deltaTime){
			yield return new WaitForFixedUpdate();
		}
		enabled = false;
	}
}
