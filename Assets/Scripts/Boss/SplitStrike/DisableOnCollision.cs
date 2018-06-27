using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnCollision : MonoBehaviour {

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Wall")){
			transform.gameObject.SetActive(false);
			Debug.Log("killed in wall collision");
		}
	}
}
