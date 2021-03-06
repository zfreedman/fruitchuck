﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Private members
    Ball _ball;
    Goal _goal;
    GoalMaker _goalMaker;
    Player _player;
    Scorer _scorer;

    private void Awake()
    {
        InitEventListeners();
        InitPhysics();
    }

    // Use this for initialization
    void Start ()
    {
        InitScorer();
        InitPlayer();
        InitGoalMaker();
        InitBall();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void DestroyOldBall()
    {
        if (_ball)
            Destroy(_ball.gameObject);
    }

    void HandleBallCollidedWithGoalEvent(Goal goal, Ball ball)
    {
        ScoreBall(goal, ball);
    }

    void HandleBallDeadEvent()
    {
        DestroyOldBall();
        InitBall();
    }

    void HandleShotEvent(Vector2 mouseChange)
    {
        if (_ball)
            _ball.HandleShotEvent(mouseChange);
    }

    void InitBall()
    {
        GameObject prefab = Prefabber.GetPrefab("Ball");
        _ball = Instantiate<GameObject>(
            prefab, Vector3.forward * -5, prefab.transform.rotation
        ).GetComponent<Ball>();
    }

    void InitEventListeners()
    {
        Ball.BallDeadEvent += HandleBallDeadEvent;
        Goal.BallCollidedWithGoalEvent += HandleBallCollidedWithGoalEvent;
        Player.ShotEvent += HandleShotEvent;
    }

    void InitGoalMaker()
    {
        _goalMaker = gameObject.AddComponent<GoalMaker>();
    }

    void InitPhysics()
    {
        Physics.gravity = Vector3.down * 30;
    }

    void InitPlayer()
    {
        _player = gameObject.AddComponent<Player>();
    }

    void InitScorer()
    {
        _scorer = new Scorer();
    }

    void ScoreBall(Goal goal, Ball ball)
    {
        HandleBallDeadEvent();
        _scorer.ScoreGoalWithBall(goal.PointsMultiplier, ball.PointsMultiplier);
    }
}
