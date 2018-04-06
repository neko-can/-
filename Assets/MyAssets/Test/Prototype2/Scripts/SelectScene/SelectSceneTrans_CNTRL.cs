using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectSceneTrans_CNTRL : MonoBehaviour {

    SelectSceneTransManager selectSceneTransManager;

	// Use this for initialization
	void Start () {
        selectSceneTransManager = GetComponent<SelectSceneTransManager>();
        selectSceneTransManager.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        selectSceneTransManager.MyUpdate();
	}
}
