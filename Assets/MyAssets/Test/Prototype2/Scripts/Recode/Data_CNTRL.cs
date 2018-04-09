using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_CNTRL : MonoBehaviour {

    testSaveTime saveTime;
    ShowClearTime showClearTime;
    RecodeSceneManager recodeSceneManager;

	// Use this for initialization
	void Start () {
        saveTime = GetComponent<testSaveTime>();
        showClearTime = GetComponent<ShowClearTime>();
        recodeSceneManager = GetComponent<RecodeSceneManager>();
        saveTime.MyStart();
        showClearTime.MyStart();
        recodeSceneManager.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        saveTime.MyUpdate();
        recodeSceneManager.MyUpdate();
	}
}
