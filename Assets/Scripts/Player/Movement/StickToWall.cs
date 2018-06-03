using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToWall : MonoBehaviour
{

    private FakeGravity fg;
    // Use this for initialization
    void Start()
    {
        fg = GetComponent<FakeGravity>();
    }
    void OnCollisionEnter(Collision other)
    {
        GameObject otherObj = other.gameObject;
        if (otherObj.CompareTag("Wall"))
        {
            Vector3 pos = otherObj.transform.position;
            if (pos.x > 1) fg.setGravity(new Vector3(1, 0, 0));
            else if (pos.x < -1) fg.setGravity(new Vector3(-1, 0, 0));
            else if (pos.y > 1) fg.setGravity(new Vector3(0, 1, 0));
            else if (pos.y < -1) fg.setGravity(new Vector3(0, -1, 0));
        }
    }
}
