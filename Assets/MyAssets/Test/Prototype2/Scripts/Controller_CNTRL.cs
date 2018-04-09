using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_CNTRL : MonoBehaviour {

    [HideInInspector] public SceneTransition sceneTransition;
    [HideInInspector] public GameObject MainCamera;

	// Use this for initialization
	void Start () {
        sceneTransition = GetComponent<SceneTransition>();
        MainCamera = GameObject.Find("Player/Main Camera");
        

        sceneTransition.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        sceneTransition.MyUpdate();
	}
}
