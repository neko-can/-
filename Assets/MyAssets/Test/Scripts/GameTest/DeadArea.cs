using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadArea : MonoBehaviour {

    //IsTrigger

    [HideInInspector] public GameObject DeadEnterObj = null;
    [HideInInspector] public bool IsOnEnterDeadArea;

    private void OnTriggerEnter(Collider other)
    {
        DeadEnterObj = other.gameObject;
        IsOnEnterDeadArea = true;
    }

    public void MyUpdate()
    {
        IsOnEnterDeadArea = false;
    }

}
