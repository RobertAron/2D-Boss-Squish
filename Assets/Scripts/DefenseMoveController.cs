using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseMoveController : MonoBehaviour {
	public GameObject defenseOrbBase;
	private GameObject[] orbs;
	// Use this for initialization
	void Start () {
		orbs = new GameObject[10];
		for(int i=0;i<10;i++)
		{
			orbs[i] = Object.Instantiate(defenseOrbBase,Vector3.zero,Quaternion.identity,transform);
		}
	}
	
	public void DefenseMove(int orbAmount)
	{
		float rotationOffset = 360f/orbAmount;
		float currentRotation = 0f;
		for(int i=0;i<orbAmount;i++)
		{
			currentRotation+=rotationOffset;
			orbs[i].transform.rotation = Quaternion.Euler(0,0,currentRotation);
			StartCoroutine(orbs[i].transform.GetChild(0).GetComponent<DefenseOrbMovement2>().Move());
		}
	}
}
