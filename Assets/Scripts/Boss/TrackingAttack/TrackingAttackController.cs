using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingAttackController : MonoBehaviour {

	public GameObject trackingAttackPrefab;
	public Transform player;
	private GameObject[] trackingAttacks;

	float timeBetweenAttacks = 1;
	// Use this for initialization
	void Start () {
		trackingAttacks = new GameObject[10];
		for(int i = 0;i<10;i++){
			trackingAttacks[i] = Instantiate(trackingAttackPrefab,transform.position,Quaternion.identity,transform);
		}
	}

	public IEnumerator TrackingAttack(int attackAmount){
		float angleSign = 1;
		for(int i = 0;i<attackAmount;i++){
			angleSign *=-1;

			Vector3 targetVector = (player.position - transform.position).normalized;
			float angle = Mathf.Atan2(targetVector.y, targetVector.x) * Mathf.Rad2Deg;
			angle += angleSign * 40;
			Debug.Log(angle);
			trackingAttacks[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

			trackingAttacks[i].transform.position = transform.position;
			trackingAttacks[i].SetActive(true);
			MonoBehaviour[] monoBehaviours = trackingAttacks[i].GetComponents<MonoBehaviour>();
			foreach(MonoBehaviour monoBehaviour in monoBehaviours)
				monoBehaviour.enabled = true;

			for(float delayedTime = 0;delayedTime<timeBetweenAttacks;delayedTime+=Time.deltaTime){
				yield return new WaitForFixedUpdate();
			}
		}
	}
}
