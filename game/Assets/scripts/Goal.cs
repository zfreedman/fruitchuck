using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    // Private members

	// Use this for initialization
	void Start ()
    {
        name = "Goal";
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void PlaceGoal()
    {
        transform.position = Vector3.forward * 10;
    }
}
