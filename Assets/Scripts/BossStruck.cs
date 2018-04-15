using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStruck : MonoBehaviour {


	private Deform.Deformers.CurveDeformer bossDeform;
	public GameObject deformedAxis;
	private Transform deformedTransformAxis;
	private Transform bossPosition;
	private float hitDampen = 15;
	private float strikeTime = 0.1f;
	private float bounceTime = 0.15f;
	private bool callSub = true;
	void Start()
	{
		bossDeform = GetComponent<Deform.Deformers.CurveDeformer>();
		deformedTransformAxis = deformedAxis.GetComponent<Transform>();
		bossPosition = GetComponent<Transform>(); 
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player")){
			Rigidbody otherRigid = other.GetComponent<Rigidbody>();
			float hitStrength = otherRigid.velocity.magnitude;
			Vector3 hitDirection = otherRigid.velocity.normalized;
			// TODO: find hit location so the deform isn't always centered.
			if(callSub) StartCoroutine(stretchBounceCoroutine(hitDirection,hitStrength,0.5f));
		}
	}


	/// <summary>
	/// Deforms the boss. Quickly moves to full deform, bounces back and past, then back to resing position.
	/// </summary>
	private IEnumerator stretchBounceCoroutine(Vector3 hitDirection, float hitStrength, float hitPosition){
		callSub = false;
		Vector3 center = new Vector3(0,0,0);
		float maxStrength = hitStrength/hitDampen;
		float secondStrength = maxStrength*-0.3f;
		deformedTransformAxis.rotation = Quaternion.Euler(Mathf.Atan2(hitDirection.y*-1,hitDirection.x)*Mathf.Rad2Deg-90,90,0);
		Vector3 maxPosition = hitDirection*maxStrength;
		Vector3 secondPosition = maxPosition*-0.3f;
		// Strike
		while(Mathf.Abs(maxStrength - bossDeform.strength) > Mathf.Epsilon)
		{
			Debug.Log(maxStrength-bossDeform.strength);
			bossDeform.strength = Mathf.MoveTowards(bossDeform.strength,maxStrength,Time.deltaTime/strikeTime);
			bossPosition.position = Vector3.MoveTowards(bossPosition.position,maxPosition,Time.deltaTime/strikeTime);
			yield return null;
		}
		// Bounce
		while(Mathf.Abs(secondStrength - bossDeform.strength) > Mathf.Epsilon)
		{
			Debug.Log("Bounce");
			bossDeform.strength = Mathf.MoveTowards(bossDeform.strength,secondStrength,Time.deltaTime/bounceTime);
			bossPosition.position = Vector3.MoveTowards(bossPosition.position,secondPosition,Time.deltaTime/bounceTime);
			yield return null;
		}
		// Return
		while(Mathf.Abs(0f - bossDeform.strength) > Mathf.Epsilon)
		{
			Debug.Log("Return");
			bossDeform.strength = Mathf.MoveTowards(bossDeform.strength,0f,Time.deltaTime/bounceTime);
			bossPosition.position = Vector3.MoveTowards(bossPosition.position,center,Time.deltaTime/bounceTime);
			yield return null;
		}
		callSub = true;
	}
}
