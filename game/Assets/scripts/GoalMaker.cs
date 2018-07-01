using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalMaker : MonoBehaviour
{
    // Private members
    int _goalsMadeCount;
    List<GameObject> _holderPrefabs;
    Dictionary<string, GoalHolder> _holders;
    [SerializeField] int _minTimeBetweenNewGoals = 2;
    [SerializeField] int _maxTimeBetweenNewGoals = 5;
    [SerializeField] float _timeBetweenNewGoals = 1;

	void Awake ()
    {
    }

    // Use this for initialization
    void Start()
    {
        InitEventListeners();
        InitHolderPrefabs();
        InitHolders();
    }

    // Update is called once per frame
    void Update ()
    {
        UpdateTimeBetweenNewGoals();
	}

    Vector3 GetGoalPosition(GameObject holderPrefab)
    {
        return holderPrefab.GetComponent<GoalHolder>().GoalPosition;
    }

    void HandleGoalHolderLifetime0Event(string holderName)
    {
        Destroy(_holders[holderName].gameObject);
        _holders.Remove(holderName);
    }

    void InitEventListeners()
    {
        GoalHolder.GoalHolderLifetime0Event += HandleGoalHolderLifetime0Event;
    }

    void InitHolderPrefabs()
    {
        _holderPrefabs = new List<GameObject>(
            Resources.LoadAll<GameObject>("prefabs/world/goalHolders")
        );
    }

    void InitHolders()
    {
        _holders = new Dictionary<string, GoalHolder>();
    }

    GoalHolder MakeGoalHolder()
    {
        Vector3 holderPosition = PickRandomHolderPosition();
        GameObject holderPrefab = PickRandomHolderPrefab();
        GoalHolder holder = Instantiate(
            holderPrefab, holderPosition, holderPrefab.transform.rotation
        ).GetComponent<GoalHolder>();
        holder.name = "Holder " + _goalsMadeCount;

        return holder;
    }

    void MakeGoal()
    {
        GoalHolder holder = MakeGoalHolder();
        _holders.Add(holder.name, holder);

        Vector3 goalPosition = GetGoalPosition(holder.gameObject);
        GameObject goalPrefab = Prefabber.GetPrefab("Goal");
        Goal goal = Instantiate(
            goalPrefab, holder.transform
        ).AddComponent<Goal>();
        goal.name = "Goal " + _goalsMadeCount;
        goal.transform.position = goalPosition;

        _goalsMadeCount++;
    }

    Vector3 PickRandomHolderPosition()
    {
        Vector3 position = Vector3.forward * 10;
        // if (_goalsMade != 0)
        if (true)
        {
            position = new Vector3(
                Random.Range(-5, 5),
                0,
                Random.Range(0, 5)
            );
        }
        return position;
    }

    GameObject PickRandomHolderPrefab()
    {
        return _holderPrefabs[Random.Range(0, _holderPrefabs.Count)];
    }

    void ResetTimeBetweenNewGoals()
    {
        _timeBetweenNewGoals = Random.Range(
            _minTimeBetweenNewGoals,
            _maxTimeBetweenNewGoals
        );
    }

    void UpdateTimeBetweenNewGoals()
    {
        _timeBetweenNewGoals -= Time.deltaTime;
        if (_timeBetweenNewGoals < 0)
        {
            MakeGoal();
            ResetTimeBetweenNewGoals();
        }
    }
}
