using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Private members
    Ball _ball;
    Vector2 _prevMouse;
    

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
        if (_ball)
            ControlBall();
	}

    void FixedUpdate()
    {
    }

    void ControlBall()
    {
        _ball.transform.position = Camera.main.ScreenToWorldPoint(
            Input.mousePosition + Vector3.forward * 3
        );
    }

    void ControlBallStart()
    {
        _ball.TogglePhysics(false);
    }

    void ControlBallStop()
    {
        _ball.TogglePhysics(true);
    }

    void FindBall()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
            _ball = hit.transform.GetComponent<Ball>();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
            HandleMouseDown();
        else if (Input.GetMouseButtonUp(0))
            HandleMouseUp();
        else if (Input.GetMouseButton(0))
            HandleMouseHold();
    }

    void HandleMouseDown()
    {
        FindBall();
        if (_ball)
            ControlBallStart();
    }

    void HandleMouseHold()
    {
        _prevMouse = Input.mousePosition;
    }

    void HandleMouseUp()
    {
        if (_ball)
        {
            ReleaseBall();
            if (ShotEvent != null)
                ShotEvent((Vector2)Input.mousePosition - _prevMouse);
        }
    }

    void ReleaseBall()
    {
        ControlBallStop();
        _ball = null;
    }
}
