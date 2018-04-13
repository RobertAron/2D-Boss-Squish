using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float speed = 1f;
    public float timeToMaxSpeed = 0.1f;

    private Rigidbody2D rigidbody;

    private Vector2 goalVelocity;
    private Vector2 curentVelocityRef;

    // Use this for initialization
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        goalVelocity.Normalize();
        goalVelocity *= speed;
        Debug.Log("Update to Velocity" + goalVelocity);
        rigidbody.velocity = Vector2.SmoothDamp(rigidbody.velocity, goalVelocity, ref curentVelocityRef, timeToMaxSpeed, float.MaxValue, Time.deltaTime);
    }
    public void MoveHorizontal(float amount)
    {
        goalVelocity.x = amount;
    }
    public void MoveVertical(float amount)
    {
        goalVelocity.y = amount;
    }
}
