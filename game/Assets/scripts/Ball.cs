using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Private members
    private Rigidbody _rigidbody;
    private bool _useGravity;

	// Use this for initialization
	void Start ()
    {
        name = "Ball";
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void AddPhysics()
    {
        _rigidbody = gameObject.AddComponent<Rigidbody>();
        _useGravity = false;
        _rigidbody.useGravity = _useGravity;
    }
}
