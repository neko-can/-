using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalArea : MonoBehaviour {

    [HideInInspector] public GameObject GoalEnterObj;
    [HideInInspector] public bool IsOnEnterGoalArea;

    private void OnTriggerEnter(Collider other)
    {
        GoalEnterObj = other.gameObject;
        IsOnEnterGoalArea = true;
    }

    public void MyUpdate()
    {
        IsOnEnterGoalArea = false;
    }
}
