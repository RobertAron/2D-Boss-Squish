using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseOrbMovement2 : MonoBehaviour {
	public float timeToInitialLocation =  1f;
	public float timeTillBeginFade = 5f;
	public float timeTillFullFade = 6f;
	public float spinSpeed = 1f;
	private Vector3 startingPosition = new Vector3(0, 0, 0);
	private Vector3 fullLengthPosition = new Vector3(1, 0, 0);
	private Vector3 startingScale = new Vector3(0.2f,0.2f,0.2f);
	private Vector3 endingScale = new Vector3(0,0,0);

	public IEnumerator Move()
	{
		transform.gameObject.SetActive(true);
		transform.localScale = startingScale;
		float timePassed = 0f;
		while(timePassed<timeToInitialLocation)
		{
			timePassed+=Time.fixedDeltaTime;
			transform.localPosition = Vector3.Lerp(startingPosition, fullLengthPosition, timePassed / timeToInitialLocation);
			Debug.Log(transform.localPosition);
			yield return new WaitForFixedUpdate();
		}
		while(timePassed<timeTillBeginFade)
		{
			timePassed+=Time.fixedDeltaTime;
			updateParentRotation();
			yield return new WaitForFixedUpdate();
		}
		while(timePassed<timeTillFullFade)
		{
			timePassed+=Time.fixedDeltaTime;
			updateParentRotation();
			transform.localScale = Vector3.Lerp(startingScale,endingScale,(timePassed - timeTillBeginFade)/(timeTillFullFade - timeTillBeginFade));
			yield return new WaitForFixedUpdate();
		}
		// transform.gameObject.SetActive(false);
		yield return new WaitForFixedUpdate();
	}

	void updateParentRotation()
	{
		Vector3 parentRotation = transform.parent.rotation.eulerAngles;
		parentRotation.z += spinSpeed;
		transform.parent.rotation = Quaternion.Euler(parentRotation);
	}
}
