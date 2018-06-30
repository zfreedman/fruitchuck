using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Private members
    Player _player;
    Ball _ball;
    Goal _goal;

	// Use this for initialization
	void Start ()
    {
        AddEventListeners();
        InitPhysics();
        InitPlayer();
        InitGoal();
        InitBall();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void AddEventListeners()
    {
        Ball.BallDeadEvent += HandleBallDeadEvent;
        Player.ShotEvent += HandleShotEvent;
    }

    void DestroyOldBall()
    {
        if (_ball)
            Destroy(_ball.gameObject);
    }

    void HandleBallDeadEvent()
    {
        DestroyOldBall();
        InitBall();
    }

    void HandleShotEvent(Vector2 mouseChange)
    {
        print(mouseChange);
        if (_ball)
            _ball.HandleShotEvent(mouseChange);
    }

    void InitBall()
    {
        _ball = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Ball>();
    }

    void InitGoal()
    {
        _goal = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Goal>();
    }

    void InitPlayer()
    {
        _player = gameObject.AddComponent<Player>();
    }

    void InitPhysics()
    {
        Physics.gravity = Vector3.down * 15;
    }
}
