using System;
using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;

public class RaySceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public delegate void raySceneDelegate();
public class RaySceneManagement
{
    GameObject MainCamera;
    GameObject[] ButtonArray;
    raySceneDelegate[] RayScenes;
    KeyCode[] KeyCodeArray;
    KeyCode? downKeyCode;
    Vector3 rayStartPos;
    Vector3 rayDirection;
    Ray ray;
    RaycastHit raycastHit;
    int ButtonIndex = -1;
    bool buttonSwitch = false;

    public RaySceneManagement(GameObject[] buttonArray, raySceneDelegate[] rayScenes, KeyCode[] testKeyArray)
    {
        MainCamera = GameObject.Find("Player/Main Camera");
        ButtonArray = buttonArray;
        RayScenes = rayScenes;
        KeyCodeArray = testKeyArray;
    }

    public void MyUpdate()
    {
        rayStartPos = MainCamera.transform.position;
        rayDirection = MainCamera.transform.forward;
        ray = new Ray(rayStartPos, rayDirection);
        if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity) && Input.GetMouseButton(0))
        {
            ButtonIndex = Array.IndexOf(ButtonArray, raycastHit.collider.gameObject);
            if(ButtonIndex != -1)
            {
                buttonSwitch = true;
            }
        }

        TestTrans();

        if(buttonSwitch)
        {
            RayScenes[ButtonIndex]();
        }
    }

    void TestTrans()
    {
        downKeyCode = GetKeyDownCode.getKeyDownCode();
        if(!buttonSwitch)
        {
            ButtonIndex = Array.IndexOf(KeyCodeArray, downKeyCode);
            if (ButtonIndex != -1)
            {
                buttonSwitch = true;
            }
        }
    }
}
