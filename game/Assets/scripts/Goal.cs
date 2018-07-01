using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Private members
    int _goalLife = 1;
    int _pointsMultiplier = 1;

    // Accessor
    public int PointsMultiplier
    {
        get { return _pointsMultiplier; }
    }

    // Events
    public delegate void BallCollidedWithGoalEventListener(Goal goal, Ball ball);
    public static event BallCollidedWithGoalEventListener BallCollidedWithGoalEvent;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    Ball BallFromCollision(Collision collision)
    {
        Ball ball = collision.gameObject.GetComponent<Ball>();
        // Check to make sure something didn't hit the ball before the user grabbed it
        return ball.Grabbable ? null : ball;
    }

    void HandleCollisionEnter(Ball ball)
    {
        if (ball && BallCollidedWithGoalEvent != null)
        {
            if (_goalLife > 0)
            {
                BallCollidedWithGoalEvent(this, ball);
            }
            UpdateGoalLife(-1);
            UpdateGoalMaterial();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Ball ball = BallFromCollision(collision);
        HandleCollisionEnter(ball);
    }

    void UpdateGoalLife(int delta)
    {
        _goalLife += delta;
        if (_goalLife <= 0)
        {
            ;
        }
    }

    void UpdateGoalMaterial()
    {
        if (_goalLife <= 0)
        {
            Material newMaterial = Materializer.GetMaterial("Dead Goal");
            gameObject.GetComponent<Renderer>().material = newMaterial;
        }
    }
}
