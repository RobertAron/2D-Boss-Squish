using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenseMove : MonoBehaviour {
	public GameObject orbPrefab;
	public void Initialize(int orbAmount)
	{
		int orbIndex = 0;
		float orbAngle = 0f;
		float orbAngleDiff = 360f/orbAmount;
		for(orbIndex=0;orbIndex<orbAmount;orbIndex++)
		{
			orbAngle += orbAngleDiff;
			Debug.Log(orbAngle);
			Object.Instantiate(orbPrefab,Vector3.zero,Quaternion.Euler(0,0,orbAngle),transform);
		}
	}
}
