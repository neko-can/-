using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRTo_CNTRL : MonoBehaviour {

    XRAdvance xrAdvance;

	// Use this for initialization
	void Start () {
        xrAdvance = GetComponent<XRAdvance>();
        xrAdvance.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        xrAdvance.MyUpdate();
	}
}
