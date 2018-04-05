using System;
using System.Collections;
using System.Collections.Generic;
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
    Vector3 rayStartPos;
    Vector3 rayDirection;
    Ray ray;
    RaycastHit raycastHit;
    int ButtonIndex = -1;

    public RaySceneManagement(GameObject[] buttonArray, raySceneDelegate[] rayScenes)
    {
        MainCamera = GameObject.Find("Player/Main Camera");
        ButtonArray = buttonArray;
        RayScenes = rayScenes;
    }

    public void MyUpdate()
    {
        rayStartPos = MainCamera.transform.position;
        rayDirection = MainCamera.transform.forward;
        ray = new Ray(rayStartPos, rayDirection);
        if(Physics.Raycast(ray, out raycastHit, Mathf.Infinity))
        {
            ButtonIndex = Array.IndexOf(ButtonArray, raycastHit.collider.gameObject);
        }

        if(ButtonIndex != -1)
        {
            RayScenes[ButtonIndex]();
        }
    }
}
