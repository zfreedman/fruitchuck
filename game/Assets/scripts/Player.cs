using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Private members
    Vector2 _mouseDown;
    Vector2 _prevMouse;
    Vector2 _mouseUp;

    // Public members

    // Events
    public delegate void ShotEventListener(Vector2 mouseChange);
    public static event ShotEventListener ShotEvent;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
	}

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
            HandleMouseDown();
        else if (Input.GetMouseButton(0))
            HandleMouseHold();
        if (Input.GetMouseButtonUp(0))
            HandleMouseUp();
    }

    void HandleMouseDown()
    {
        _mouseDown = Input.mousePosition;
    }

    void HandleMouseHold()
    {
        _prevMouse = Input.mousePosition;
    }

    void HandleMouseUp()
    {
        if (ShotEvent != null)
            ShotEvent((Vector2)Input.mousePosition - _prevMouse);
    }
}
