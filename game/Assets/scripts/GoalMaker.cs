using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMaker : MonoBehaviour
{
    // Private members
    int _goalsMade;
    List<GameObject> _holderPrefabs;

	// Use this for initialization
	void Awake ()
    {
        InitHolderPrefabs();
	}
	
	// Update is called once per frame
	void Update ()
    {
	}

    Vector3 GetGoalPosition(GameObject holderPrefab)
    {
        return holderPrefab.GetComponent<GoalHolder>().GoalPosition;
    }

    void InitHolderPrefabs()
    {
        _holderPrefabs = new List<GameObject>(
            Resources.LoadAll<GameObject>("prefabs/world/goalHolders")
        );
    }

    public GoalHolder MakeGoalHolderController()
    {
        Vector3 holderPosition = PickRandomHolderPosition();
        GameObject holderPrefab = PickRandomHolderPrefab();
        GoalHolder holder = Instantiate(
            holderPrefab, holderPosition, holderPrefab.transform.rotation
        ).GetComponent<GoalHolder>();
        holder.name = "Holder " + _goalsMade;

        return holder;
    }

    public Goal MakeGoal()
    {
        GoalHolder holder = MakeGoalHolderController();

        Vector3 goalPosition = GetGoalPosition(holder.gameObject);
        GameObject goalPrefab = Prefabber.GetPrefab("Goal");
        Goal goal = Instantiate(
            goalPrefab, holder.transform
        ).AddComponent<Goal>();
        goal.name = "Goal " + _goalsMade;
        goal.transform.position = goalPosition;

        _goalsMade++;
        return goal;
    }

    public Vector3 PickRandomHolderPosition()
    {
        Vector3 position = Vector3.forward * 10;
        // if (_goalsMade != 0)
        if (true)
        {
            position = new Vector3(
                Random.Range(-5, 5),
                0,
                Random.Range(3, 7)
            );
        }
        return position;
    }

    public GameObject PickRandomHolderPrefab()
    {
        return _holderPrefabs[Random.Range(0, _holderPrefabs.Count)];
    }
}
