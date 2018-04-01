using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanCollider : MonoBehaviour {

    [HideInInspector] public GameObject otherCllider = null;
    GameObject previousCollider = null;
    [HideInInspector] public bool IsHit = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    private void OnCollisionEnter(Collision collision)
    {
        otherCllider = collision.gameObject;
    }
    private void OnCollisionStay(Collision collision)
    {
        otherCllider = collision.gameObject;
    }

    public void MyUpdate()
    {
        if (otherCllider != null)
        {
            previousCollider = otherCllider;
            if (otherCllider.transform.parent.name == "Walls")
            {
                IsHit = true;
            }
            otherCllider = null;

        }
        else
        {
            IsHit = false;
        }
    }
}
