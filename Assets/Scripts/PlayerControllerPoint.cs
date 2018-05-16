using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPoint : MonoBehaviour {
	private int clickableArea;
	private const float CAM_RAY_LENGTH = 100f;
	private LineRenderer aimLine;

	public GameObject aimEffect;
	public float moveSpeed = 10;

	void Awake()
	{
		clickableArea = LayerMask.GetMask("2D Plane");
		aimLine = aimEffect.GetComponent<LineRenderer>();
	}
	
	void FixedUpdate()
	{
		// Debug.Log(Input.mousePosition);
		if(true)//eventual change to mouse down
		{
			drawAim();
		}
		if(Input.GetMouseButtonUp(0))//TODO add when logic
		{
			Debug.Log("Mouse Released");
		}
	}



	void drawAim(){
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast(camRay,out floorHit,CAM_RAY_LENGTH,clickableArea))
		{
			aimLine.enabled = true;
			aimEffect.transform.LookAt(floorHit.point);
		}
	}
}
