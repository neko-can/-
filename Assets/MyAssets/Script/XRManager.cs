using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class XRManager : MonoBehaviour {

    public bool XRSupport = false;

	// Use this for initialization
	void Start () {
        XRSettings.enabled = XRSupport;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
