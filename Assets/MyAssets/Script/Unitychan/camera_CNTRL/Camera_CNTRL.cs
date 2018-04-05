using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_CNTRL : MonoBehaviour {

    //source
    [HideInInspector] public testCNTRLs cntrls;
    //script_set
    Camera_CNTRL_Initializer camera_CNTRL_Initializer;
    //script
    [HideInInspector] public ViewerForRunning viewerForRunning;

    //variable
    [HideInInspector] public GameObject unitychan;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public GameObject MainCamera;

	// Use this for initialization
	void Start () {
        //必要な変数
        //source
        cntrls = transform.parent.GetComponent<testCNTRLs>();
        //script_set
        camera_CNTRL_Initializer = GetComponent<Camera_CNTRL_Initializer>();

        //処理
        //script_set
        camera_CNTRL_Initializer.MyStart();
        //script
        viewerForRunning.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        //script
        viewerForRunning.MyUpdate();
	}
}
