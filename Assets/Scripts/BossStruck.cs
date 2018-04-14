using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStruck : MonoBehaviour {

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>

	public Deform.Deformers.CurveDeformer bossDeform;
	public GameObject curveAxis;
	private Transform curveTransform;
	/// <summary>
	/// Start is called on the frame when a script is enabled just before
	/// any of the Update methods is called the first time.
	/// </summary>
	void Start()
	{
		bossDeform = GetComponent<Deform.Deformers.CurveDeformer>();
		curveTransform = curveAxis.GetComponent<Transform>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player")){
			Debug.Log("WHOO!!");
			Rigidbody otherRigid = other.GetComponent<Rigidbody>();
			float hitStrength = otherRigid.velocity.magnitude;
			Vector3 hitDirection = otherRigid.velocity.normalized;
			bossDeform.strength = hitStrength/20;
			curveTransform.rotation = Quaternion.Euler(Mathf.Atan2(hitDirection.y*-1,hitDirection.x)*Mathf.Rad2Deg-90,90,0);
		}
	}
}
