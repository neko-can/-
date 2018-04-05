using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_CNTRL : MonoBehaviour {

    testRay TestRay;
    [HideInInspector] public SceneTransition sceneTransition;
    [HideInInspector] public GameObject MainCamera;

	// Use this for initialization
	void Start () {
        TestRay = GetComponent<testRay>();
        sceneTransition = GetComponent<SceneTransition>();
        MainCamera = GameObject.Find("Player/Main Camera");
        

        TestRay.MyStart();
        sceneTransition.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        TestRay.MyUpdate();
        sceneTransition.MyUpdate();
	}
}
