using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMaker : MonoBehaviour
{
    // Private members
    int _goalsMade;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    public Vector3 MakeGoalPosition()
    {
        Vector3 position = Vector3.forward * 10;
        if (_goalsMade != 0)
        {
            position = new Vector3(
                Random.Range(-3, 3),
                Random.Range(-2, 2),
                Random.Range(5, 15)
            );

        }
        return position;
    }

    public Goal MakeGoal()
    {
        Vector3 position = MakeGoalPosition();
        GameObject prefab = Prefabber.GetPrefab("Goal");
        Goal goal = Instantiate(
            prefab, position, prefab.transform.rotation
        ).AddComponent<Goal>();
        goal.name = "Goal " + _goalsMade++;
        return goal;
    }
}
