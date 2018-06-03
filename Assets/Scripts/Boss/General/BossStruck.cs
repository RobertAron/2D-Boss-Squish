using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStruck : MonoBehaviour {

	private const float STRIKE_ANGLE_MODIFY = 1f/60f;
	private Deform.Deformers.CurveDeformer bossDeform;
	public GameObject deformedAxis;
	private Transform deformedTransformAxis;
	private Transform bossPosition;
	public float deformDampen = 0.035f;
	public float distanceDampen = 0.1f;
	public float strikeTime = 0.05f;
	public float bounceTime = 0.1f;
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
			if(callSub) StartCoroutine(stretchBounceCoroutine(hitDirection,hitStrength,otherRigid.position));
		}
	}


	/// <summary>
	/// Deforms the boss. Quickly moves to full deform, bounces back and past, then back to resing position.
	/// </summary>
	private IEnumerator stretchBounceCoroutine(Vector3 hitDirection, float hitStrength, Vector3 hitPosition){
		callSub = false;
		float maxStrength = hitStrength*deformDampen;
		float secondStrength = maxStrength*-0.3f;
		float initStrength = bossDeform.strength;
		Vector3 maxPosition = hitDirection*distanceDampen*hitStrength;
		Vector3 secondPosition = maxPosition*-0.3f;
		Vector3 bossInitPosition = bossPosition.position;
		deformedTransformAxis.rotation = Quaternion.Euler(Mathf.Atan2(hitDirection.y*-1,hitDirection.x)*Mathf.Rad2Deg-90,90,0);
		Vector3 centerToHitPositionAxis = hitPosition-bossInitPosition;
		float angleStruck = Vector3.Angle(centerToHitPositionAxis.normalized,deformedTransformAxis.rotation * Vector3.back);
		if(angleStruck<60){
			bossDeform.curve = new AnimationCurve(new Keyframe(0f,0f), new Keyframe(1f,1f));
		}else if(angleStruck>120){
			bossDeform.curve = new AnimationCurve(new Keyframe(0f,1f), new Keyframe(1f,0f));
		}else{
			float strikePosition = (angleStruck-60)*STRIKE_ANGLE_MODIFY;
			bossDeform.curve = new AnimationCurve(new Keyframe(0f,1f),new Keyframe(strikePosition,0f), new Keyframe(1f,1f));
		}
		


		// Strike
		float percentage = 0f;
		while(Mathf.Abs(maxStrength - bossDeform.strength) > Mathf.Epsilon)
		{
			percentage += Time.deltaTime/strikeTime;
			bossDeform.strength = Mathf.Lerp(initStrength,maxStrength,percentage);
			bossPosition.position = Vector3.Lerp(bossInitPosition,maxPosition,percentage);
			yield return null;
		}
		// Bounce
		percentage = 0f;
		while(Mathf.Abs(secondStrength - bossDeform.strength) > Mathf.Epsilon)
		{
			percentage += Time.deltaTime/bounceTime;
			bossDeform.strength = Mathf.Lerp(maxStrength,secondStrength,percentage);
			bossPosition.position = Vector3.Lerp(maxPosition,secondPosition,percentage);
			yield return null;
		}
		// Return
		percentage = 0f;
		while(Mathf.Abs(0f - bossDeform.strength) > Mathf.Epsilon)
		{
			percentage += Time.deltaTime/bounceTime;
			bossDeform.strength = Mathf.Lerp(secondStrength,0f,percentage);
			bossPosition.position = Vector3.Lerp(secondPosition,bossInitPosition,percentage);
			yield return null;
		}
		callSub = true;
	}
}
