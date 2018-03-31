using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDirection : MonoBehaviour {

    public GameObject MainChamera;
    Vector3 direction;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        direction = MainChamera.transform.forward;
        direction.y = 0f;

        transform.forward = direction;
	}
}
