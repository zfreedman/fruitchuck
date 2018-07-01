using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InitScoreEventListener();
	}

    void InitScoreEventListener()
    {
        Scorer.ScoreUpdatedEvent += HandleScoreUpdatedEvent;
    }

    void HandleScoreUpdatedEvent(int newScore)
    {
        gameObject.GetComponent<Text>().text = newScore.ToString();
    }
}
