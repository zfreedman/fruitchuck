using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Private members

    // Events
    public delegate void BallCollidedWithGoalEventListener(Goal goal, Ball ball);
    public static event BallCollidedWithGoalEventListener BallCollidedWithGoalEvent;

	// Use this for initialization
	void Start ()
    {
        name = "Goal";
        PlaceGoal();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    Ball BallFromCollision(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        return ball;
    }

    void HandleCollisionEnter(Ball ball)
    {
        if (ball && BallCollidedWithGoalEvent != null)
        {
            BallCollidedWithGoalEvent(this, ball);
        }
    }

    void PlaceGoal()
    {
        transform.position = Vector3.forward * 10;
    }

    void OnCollisionEnter(Collision collision)
    {
        Ball ball = BallFromCollision(collision);
        HandleCollisionEnter(ball);
    }


}
