using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testPublicObject : MonoBehaviour {

    //変数用意
    testButton TestButton;

    public void MyStart()
    {
            TestButton = GetComponent<testButton>();
            Debug.Log(TestButton.publicObject.name);
    }
    public void MyUpdate()
    {
    }
    public void OnChanged()
    {
    }
}
