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
        InitPlayer();
        InitGoal();
        InitBall();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void HandleShotEvent(Vector2 mouseChange)
    {
        print(mouseChange);
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
        Player.ShotEvent += HandleShotEvent;
    }
}
