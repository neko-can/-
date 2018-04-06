using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualScene_CNTRL : MonoBehaviour {

    ManualSceneManager manualSceneManager;

	// Use this for initialization
	void Start () {
        manualSceneManager = GetComponent<ManualSceneManager>();
        manualSceneManager.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        manualSceneManager.MyUpdate();
	}
}
