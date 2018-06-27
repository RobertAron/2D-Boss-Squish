using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitOnCollision : MonoBehaviour {

	//need sub objects
	public GameObject splitBulletsPrefab;
	GameObject splitStuckBullet1;
	GameObject splitStuckBullet2;
	public float wallSepeartion = 0.1f;

	private void Start() {
		splitStuckBullet1 = Object.Instantiate(splitBulletsPrefab,Vector3.zero,Quaternion.identity,transform.parent);
		splitStuckBullet2 = Object.Instantiate(splitBulletsPrefab,Vector3.zero,Quaternion.identity,transform.parent);
		Debug.Log(splitStuckBullet1);
	}

	private void OnCollisionEnter(Collision other) {
		if(other.gameObject.CompareTag("Wall")){
			Debug.Log("attempting split");
			Vector3 splitRotation1 = Quaternion.Euler(0, 0, 90) * other.contacts[0].normal;
			Vector3 splitRotation2 = Quaternion.Euler(0, 0, -90) * other.contacts[0].normal;
			Debug.Log(splitRotation1);
			Debug.Log(splitRotation2);
			splitStuckBullet1.transform.position = transform.position + other.contacts[0].normal * wallSepeartion;
			splitStuckBullet1.transform.rotation = Quaternion.LookRotation(splitRotation1);
			splitStuckBullet1.SetActive(true);
			splitStuckBullet2.transform.position = transform.position + other.contacts[0].normal * wallSepeartion;
			splitStuckBullet2.transform.rotation = Quaternion.LookRotation(splitRotation2);
			splitStuckBullet2.SetActive(true);
		};
	}
}
