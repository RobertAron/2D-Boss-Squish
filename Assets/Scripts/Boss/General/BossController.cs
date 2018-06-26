using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour {
	public DefenseMoveController defenseMoveController;
	public int defenseOrbSpawnAmount = 1;
	public TrackingAttackController trackingAttackController;
	public int trackingAttackAmount = 4;
	private float totalTime = 0f;
	private bool hasSpawned = false;
	
	private void Update() {
		// totalTime+= Time.deltaTime;
		// if(!hasSpawned && totalTime>1)
		// {
		// 	ActivateDefenseMove();
		// 	hasSpawned = true;
		// } 
	}

	[ContextMenu("Defense Move")]
	void ActivateDefenseMove(){
		defenseMoveController.DefenseMove(defenseOrbSpawnAmount);
	}
	[ContextMenu("TrackingMove")]
	void TrackingAttackMove(){
		StartCoroutine(trackingAttackController.TrackingAttack(trackingAttackAmount));
	}
}