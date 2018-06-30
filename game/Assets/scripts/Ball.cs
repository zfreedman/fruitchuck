using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Private members
    Rigidbody _rigidbody;
    bool _useGravity;
    float _forceScale;

    // Public members

    // Events
    public delegate void BallDeadEventListener();
    public static event BallDeadEventListener BallDeadEvent;

	// Use this for initialization
	void Start ()
    {
        name = "Ball";
        InitPhysics();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (transform.position.y < -5 && BallDeadEvent != null)
            BallDeadEvent();
	}

    void InitPhysics()
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        TogglePhysics(false);

        _forceScale = 10;
    }

    public void HandleShotEvent(Vector2 mouseChange)
    {
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(
            new Vector3(
                mouseChange.x, mouseChange.y, mouseChange.y
            ) * _forceScale
        );
    }

    public void TogglePhysics(bool usePhysics)
    {
        _useGravity = usePhysics;
        _rigidbody.useGravity = _useGravity;
        if (!usePhysics)
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = Vector3.zero;
        }
    }
}
