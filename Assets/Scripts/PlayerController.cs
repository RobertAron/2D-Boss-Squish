using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed = 1f;
    public float dampenTime = 3f;

    private Rigidbody rb;
    private Vector2 rest = new Vector2(0f,0f);
    private Vector2 curentVelocityRef;

	private int clickableArea;
    private const float CAM_RAY_LENGTH = 100f;

    public GameObject aimEffect;
    private LineRenderer aimLine;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        aimLine = aimEffect.GetComponent<LineRenderer>();
        clickableArea = LayerMask.GetMask("2D Plane");
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(rb.velocity);
        // rb.velocity = Vector2.SmoothDamp(rb.velocity, rest, ref curentVelocityRef, dampenTime, float.MaxValue, Time.deltaTime);
    }
    public void drawDirectionLine(Vector3 mouseLocation)
    {
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
		if(Physics.Raycast(camRay,out floorHit,CAM_RAY_LENGTH,clickableArea))
		{
			aimLine.enabled = true;
			aimEffect.transform.LookAt(floorHit.point);
		}
    }
    public void burstTowardsMouse(Vector3 mousePosition)
    {
        aimLine.enabled = false;
		Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
        if(Physics.Raycast(camRay,out floorHit,CAM_RAY_LENGTH,clickableArea))
        {
            Vector3 directionVector = floorHit.point - transform.position;
            Debug.Log(directionVector.normalized*speed);
            rb.velocity = directionVector.normalized*speed;
        }
    }
}
