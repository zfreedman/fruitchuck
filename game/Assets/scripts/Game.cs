using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Private members
    Ball _ball;
    Goal _goal;
    Player _player;
    Prefabber _prefabber;

    private void Awake()
    {
        AddEventListeners();
        InitPhysics();
        InitPrefabber();
    }

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
        //_ball = GameObject.CreatePrimitive(PrimitiveType.Cube).AddComponent<Ball>();
        GameObject prefab = _prefabber.GetPrefab("Ball");
        _ball = Instantiate<GameObject>(
            prefab, Vector3.zero, prefab.transform.rotation
        ).AddComponent<Ball>();
    }

    void InitGoal()
    {
        GameObject prefab = _prefabber.GetPrefab("Goal");
        _goal = Instantiate<GameObject>(
            prefab, Vector3.zero, prefab.transform.rotation
        ).AddComponent<Goal>();
    }

    void InitPhysics()
    {
        Physics.gravity = Vector3.down * 20;
    }

    void InitPlayer()
    {
        _player = gameObject.AddComponent<Player>();
    }

    void InitPrefabber()
    {
        _prefabber = gameObject.AddComponent<Prefabber>();
    }
}
