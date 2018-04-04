using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTimer : MonoBehaviour {

    float elapsedTime;
    string elapsedTimeText;
    public GameObject timerTextObj;
    double minute;
    double hour;
    double second;

    public void MyStart()
    {
        TimerReset();
    }

    public void MyUpdate()
    {
        TimerUpdate();
    }

    void TimerReset()
    {
        elapsedTime = 0f;
        minute = Math.Floor(elapsedTime / 60);
        hour = Math.Floor(minute / 60);
        second = elapsedTime % 60;
        elapsedTimeText = hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
        timerTextObj.GetComponent<Text>().text = elapsedTimeText;
    }
    void TimerUpdate()
    {
        //基本はWait状態からRun状態になったら
        elapsedTime += Time.deltaTime;
        minute = Math.Floor(elapsedTime / 60);
        hour = Math.Floor(minute / 60);
        second = elapsedTime % 60;
        elapsedTimeText = hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
        timerTextObj.GetComponent<Text>().text = elapsedTimeText;
    }

}
