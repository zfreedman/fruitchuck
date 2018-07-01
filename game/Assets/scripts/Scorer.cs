using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer
{
    // Private members
    int _score;

    // Accessors
    public int Score
    {
        get { return _score; }
    }

    // Events
    // public delegate void GoalScoredEventListener(Ball ball, Goal goal);
    // public static event GoalScoredEventListener GoalScored;
    public delegate void ScoreUpdatedEventListener(int newScore);
    public static event ScoreUpdatedEventListener ScoreUpdatedEvent;

    public Scorer()
    {
        _score = 0;
    }

    public void ScoreGoalWithBall(int goalPoints, int ballPoints)
    {
        _score += goalPoints * ballPoints;
        if (ScoreUpdatedEvent != null)
            ScoreUpdatedEvent(_score);
    }
}
