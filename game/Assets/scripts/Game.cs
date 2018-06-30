using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Private members
    private Player _player;
    private Ball _ball;
    private Goal _goal;

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

    private void InitBall()
    {
        _ball = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Ball>();
    }

    private void InitGoal()
    {
        _goal = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Goal>();
    }

    private void InitPlayer()
    {
        _player = gameObject.AddComponent<Player>();
    }
}
