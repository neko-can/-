using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecodeList_CNTRL : MonoBehaviour {

    SceneList sceneList;
    RecodeListSceneManager recodeListSceneManager;

	// Use this for initialization
	void Start () {
        sceneList = GetComponent<SceneList>();
        recodeListSceneManager = GetComponent<RecodeListSceneManager>();
        sceneList.MyStart();
        recodeListSceneManager.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        recodeListSceneManager.MyUpdate();
	}
}
