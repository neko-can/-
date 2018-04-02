using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotation : MonoBehaviour {

    public GameObject fromObject;
    public GameObject toObject;
    public GameObject AxisObject;

    Vector3 from;
    Vector3 to;
    Vector3 axis;
    float rotateSpeed = 10f;

	// Use this for initialization
	void Start () {
        axis = AxisObject.transform.forward;
    }
	
	// Update is called once per frame
	void Update () {
        RotateFromObj();
	}

    void GetAngle()
    {

    }
    void RotateFromObj()
    {
        fromObject.transform.Rotate(axis, rotateSpeed * Time.deltaTime);
    }
}
