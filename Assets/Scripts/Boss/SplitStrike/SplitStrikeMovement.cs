using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitStrikeMovement : MonoBehaviour {
	public float speed = 1;
	Rigidbody rb;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	private void OnEnable() {
		Debug.Log("im alive!");
		Debug.Log("My angle is" + transform.rotation.eulerAngles);
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = speed * transform.up;
	}
}
