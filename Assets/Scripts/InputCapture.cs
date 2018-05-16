using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class InputEvent : UnityEvent<Vector3> { }

public class InputCapture : MonoBehaviour
{

    public InputEvent onMouseReleasedEvent = new InputEvent();
    public InputEvent onMouseDownEvent = new InputEvent();
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0)) onMouseReleasedEvent.Invoke(Input.mousePosition);
        if(Input.GetMouseButton(0)) onMouseDownEvent.Invoke(Input.mousePosition);
    }
}
