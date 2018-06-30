using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Private members
    Rigidbody _rigidbody;
    bool _useGravity;
    float _forceScale;

	// Use this for initialization
	void Start ()
    {
        name = "Ball";
        AddPhysics();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void AddPhysics()
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _useGravity = false;
        _rigidbody.useGravity = _useGravity;

        _forceScale = 10;
    }

    public void HandleShotEvent(Vector2 mouseChange)
    {
        _rigidbody.useGravity = true;
        _rigidbody.AddForce(mouseChange * _forceScale);
    }
}
