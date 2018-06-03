using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
	public GameObject defenseMove;
	public int defenseOrbSpawnAmount = 1;
	private float totalTime = 0f;
	private bool hasSpawned = false;
	
	private void Update() {
		totalTime+= Time.deltaTime;
		if(!hasSpawned && totalTime>1)
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