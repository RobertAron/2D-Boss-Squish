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
			Debug.Log("normal "+ other.contacts[0].normal);
			Vector3 splitRotation1 = Quaternion.Euler(0, 0, 90) * other.contacts[0].normal;
			Vector3 splitRotation2 = Quaternion.Euler(0,0, -90) * other.contacts[0].normal;
			Vector3 splitRotation1Z = new Vector3(0,0, Mathf.Atan2(splitRotation1.x, splitRotation1.y) * Mathf.Rad2Deg);
			Vector3 splitRotation2Z = new Vector3(0,0, Mathf.Atan2(splitRotation2.x, splitRotation2.y) * Mathf.Rad2Deg);


			splitStuckBullet1.transform.position = transform.position;
			splitStuckBullet1.transform.rotation = Quaternion.Euler(splitRotation1Z);
			splitStuckBullet1.SetActive(true);

			splitStuckBullet2.transform.position = transform.position;
			splitStuckBullet2.transform.rotation = Quaternion.Euler(splitRotation2Z);
			splitStuckBullet2.SetActive(true);
		};
	}
}
