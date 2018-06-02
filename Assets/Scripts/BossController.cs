using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
	public GameObject defenseMove;
	public int defenseOrbSpawnAmount = 1;
	public float timeTillOrbSpawn = 5f;
	private float totalTime = 0f;
	private bool hasSpawned = false;
	
	// Update is called once per frame
	// void Update () {
	// 	totalTime+= Time.deltaTime;
	// 	if(totalTime> timeTillOrbSpawn && !hasSpawned)
	// 	{
	// 		var defenseInstnace = Object.Instantiate(defenseMove,Vector3.zero,Quaternion.identity,transform).GetComponent<DefenseMove>();
	// 		defenseInstnace.Initialize(3);
	// 		hasSpawned = true;
	// 	}
	// }

	private void Update() {
		totalTime+= Time.deltaTime;
		if(!hasSpawned && totalTime>5)
		{
			ActivateDefenseMove();
			hasSpawned = true;
		} 
	}

	[ContextMenu("Defense Move")]
	void ActivateDefenseMove(){
		defenseMove.GetComponent<DefenseMoveController>().DefenseMove(defenseOrbSpawnAmount);
	}
}