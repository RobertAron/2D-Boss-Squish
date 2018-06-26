using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeDisable : MonoBehaviour {
	public float timeTillGone=3;
	// Use this for initialization
	Vector3 initialScale;
	private void Awake() {
		initialScale = transform.localScale;
	}

	private void OnEnable() {
		transform.localScale = initialScale;
		StartCoroutine(fadeDestory());
	}

	IEnumerator fadeDestory(){
		for(float totalTime=0;totalTime<timeTillGone;totalTime+=Time.deltaTime){
			transform.localScale = Vector3.Lerp(initialScale,Vector3.zero,totalTime/timeTillGone);
			yield return new WaitForFixedUpdate();
		}
		enabled = false;
		transform.gameObject.SetActive(false);
	}
}
