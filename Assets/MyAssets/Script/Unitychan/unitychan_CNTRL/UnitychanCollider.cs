using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitychanCollider : MonoBehaviour {

    [HideInInspector] public GameObject otherCllider;
    GameObject previousCollider;
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

    public void MyUpdate()
    {
        if (otherCllider != previousCollider)
        {
            previousCollider = otherCllider;
            IsHit = true;
        }
        else
        {
            IsHit = false;
        }
    }
}
