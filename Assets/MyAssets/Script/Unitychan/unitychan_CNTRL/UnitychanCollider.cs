using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanCollider : MonoBehaviour {

    [HideInInspector] public GameObject otherCllider = null;
    GameObject previousCollider = null;
    [HideInInspector] public bool IsWallHit = false;
    [HideInInspector] public bool IsOnWallHit = false;
    [HideInInspector] public bool IsFloorHit = false;
    [HideInInspector] public Vector3? contactPoint = null;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        otherCllider = collision.gameObject;
        if (otherCllider.transform.parent.name == "Walls")
        {
            IsOnWallHit = true;
            contactPoint = collision.contacts[0].point;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        otherCllider = collision.gameObject;
        if (otherCllider.transform.parent.name == "Walls")
        {
            IsWallHit = true;
        }
        else if(otherCllider.transform.parent.name == "Floor")
        {
            IsFloorHit = true;
        }
    }

    public void MyUpdate()
    {
        IsWallHit = false;
        IsOnWallHit = false;
        IsFloorHit = false;
        //contactPoint = null;
        //if (otherCllider != null)
        //{
        //    previousCollider = otherCllider;
        //    if (otherCllider.transform.parent.name == "Walls")
        //    {
        //        IsHit = true;
        //    }
        //    otherCllider = null;

        //}
        //else
        //{
        //    IsHit = false;
        //}
    }
}
