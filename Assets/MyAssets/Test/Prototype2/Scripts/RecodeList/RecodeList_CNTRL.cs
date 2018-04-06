using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecodeList_CNTRL : MonoBehaviour {

    SceneList sceneList;

	// Use this for initialization
	void Start () {
        sceneList = GetComponent<SceneList>();
        sceneList.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
