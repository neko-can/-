using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowClearTime : MonoBehaviour {

    public GameObject YourTimeTextObj;
    public GameObject SceneNameTextObj;
    string yourTimeText;
    string sceneNameText;
    float yourTime;
    double hour;
    double minute;
    double second;

    public void MyStart()
    {
        //必要な変数
        yourTime = SendData.ClearTime;
        minute = Math.Floor(yourTime / 60);
        hour = Math.Floor(minute / 60);
        second = yourTime % 60;
        yourTimeText = "記録 : " + hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
        sceneNameText = SendData.StageName;

        YourTimeTextObj.GetComponent<Text>().text = yourTimeText;
        SceneNameTextObj.GetComponent<Text>().text = sceneNameText;
    }

    public void MyUpdate()
    {

    }
}
