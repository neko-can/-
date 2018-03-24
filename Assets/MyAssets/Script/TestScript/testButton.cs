using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public class testButton : MonoBehaviour {

    //必要な変数
    //publicobject
    public GameObject publicObject;
    testPublicObject testPublic;
    //button
    public static int testNumber = 0;

	// Use this for initialization
	void Start () {
        //publicobject
        testPublic = GetComponent<testPublicObject>();
        testPublic.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowOnClick()
    {
        Debug.Log(testNumber);
    }

    public void ShowOwnName()
    {
        Debug.Log(gameObject.name);
    }

    public void AddOnClick()
    {
        testNumber++;
    }

}
