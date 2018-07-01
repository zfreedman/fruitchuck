using System.Collections;
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
        AddEventListeners();
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

    void AddEventListeners()
    {
        Ball.BallDeadEvent += HandleBallDeadEvent;
        Goal.BallCollidedWithGoalEvent += HandleBallCollidedWithGoalEvent;
        Player.ShotEvent += HandleShotEvent;
    }

    void DestroyOldBall()
    {
        if (_ball)
            Destroy(_ball.gameObject);
    }

    void DestroyOldGoal()
    {
        if (_goal)
            Destroy(_goal.gameObject);
    }

    void HandleBallCollidedWithGoalEvent(Goal goal, Ball ball)
    {
        ScoreBall(goal, ball);
        MakeNewGoal();
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
            prefab, Vector3.zero, prefab.transform.rotation
        ).GetComponent<Ball>();
    }

    void InitGoalMaker()
    {
        _goalMaker = gameObject.AddComponent<GoalMaker>();
        MakeNewGoal();
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

    void MakeNewGoal()
    {
        DestroyOldGoal();
        _goal = _goalMaker.MakeGoal();
    }

    void ScoreBall(Goal goal, Ball ball)
    {
        HandleBallDeadEvent();
        _scorer.ScoreGoalWithBall(goal.PointsMultiplier, ball.PointsMultiplier);
    }
}
