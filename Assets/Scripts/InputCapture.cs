using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InputAxisEvent : UnityEvent<float> { }

public class InputCapture : MonoBehaviour
{

    private static string horizontalAxis = "Horizontal";
    private static string verticalAxis = "Vertical";

    public InputAxisEvent onHorizontalInputAxis = new InputAxisEvent();
    public InputAxisEvent onVerticalInputAxis = new InputAxisEvent();
    // Update is called once per frame
    void Update()
    {
        onHorizontalInputAxis.Invoke(Input.GetAxisRaw(horizontalAxis));
        onVerticalInputAxis.Invoke(Input.GetAxisRaw(verticalAxis));
    }
}
