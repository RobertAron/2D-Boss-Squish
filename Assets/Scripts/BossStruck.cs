using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStruck : MonoBehaviour {


	private Deform.Deformers.CurveDeformer bossDeform;
	public GameObject deformedAxis;
	private Transform deformedTransformAxis;
	private float hitDampen = 10;
	public float strikeTime = 0.1f;
	public float bounceTime = 0.1f;
	void Start()
	{
		bossDeform = GetComponent<Deform.Deformers.CurveDeformer>();
		deformedTransformAxis = deformedAxis.GetComponent<Transform>();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player")){
			Rigidbody otherRigid = other.GetComponent<Rigidbody>();
			float hitStrength = otherRigid.velocity.magnitude;
			Vector3 hitDirection = otherRigid.velocity.normalized;
			// TODO: find hit location so the deform isn't always centered.
			StartCoroutine(stretchBounceCoroutine(hitDirection,hitStrength,0.5f));
		}
	}


	/// <summary>
	/// Deforms the boss. Quickly moves to full deform, bounces back and past, then back to resing position.
	/// </summary>
	private IEnumerator stretchBounceCoroutine(Vector3 hitDirection, float hitStrength, float hitPosition){
		float maxDeform = hitStrength/hitDampen;
		float secondDeform = maxDeform*-0.3f;
		deformedTransformAxis.rotation = Quaternion.Euler(Mathf.Atan2(hitDirection.y*-1,hitDirection.x)*Mathf.Rad2Deg-90,90,0);
		// Strike
		while(Mathf.Abs(maxDeform - bossDeform.strength) > Mathf.Epsilon)
		{
			Debug.Log(maxDeform-bossDeform.strength);
			bossDeform.strength = Mathf.MoveTowards(bossDeform.strength,maxDeform,Time.deltaTime/strikeTime);
			yield return null;
		}
		// Bounce
		while(Mathf.Abs(secondDeform - bossDeform.strength) > Mathf.Epsilon)
		{
			Debug.Log("Bounce");
			bossDeform.strength = Mathf.MoveTowards(bossDeform.strength,secondDeform,Time.deltaTime/bounceTime);
			yield return null;
		}
		// Return
		while(Mathf.Abs(0f - bossDeform.strength) > Mathf.Epsilon)
		{
			Debug.Log("Return");
			bossDeform.strength = Mathf.MoveTowards(bossDeform.strength,0f,Time.deltaTime/bounceTime);
			yield return null;
		}
	}
}
