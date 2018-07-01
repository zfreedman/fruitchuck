using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalHolder : MonoBehaviour
{
    //Private members
    Vector3 _goalPosition;
    [SerializeField] float _maxSpeed = 5.0f;
    [SerializeField] float _minSpeed = 2.0f;
    Vector3 _moveDirection;
    [SerializeField] float _speed;

    // Accessors
    public Vector3 GoalPosition
    {
        get { return _goalPosition; }
    }

    private void Awake()
    {
        InitGoalPosition();
    }

    // Use this for initialization
    void Start ()
    {
        InitSpeed();
        InitMoveDirection();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(transform.forward * _speed * Time.deltaTime);
	}

    void InitGoalPosition()
    {
        Transform marker = null;
        foreach (Transform t in transform)
        {
            if (t.name == "Marker")
            {
                marker = t;
                break;
            }
        }
        _goalPosition = marker.transform.position;
    }

    void InitSpeed()
    {
        _speed = Random.Range(_minSpeed, _maxSpeed);
    }

    void InitMoveDirection()
    {
        _moveDirection = Camera.main.transform.forward;
    }
}
