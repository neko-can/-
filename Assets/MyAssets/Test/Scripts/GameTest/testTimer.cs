using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTimer : MonoBehaviour {

    testGame_CNTRL game_CNTRL;
    float elapsedTime;
    string elapsedTimeText;
    public GameObject timerTextObj;
    double minute;
    double hour;
    double second;
    //Animator
    int unitychanAnimHash;
    int WaitStateHash;

    public void MyStart()
    {
        game_CNTRL = GetComponent<testGame_CNTRL>();
        WaitStateHash = game_CNTRL.WaitStateHash;
        TimerReset();
    }

    public void MyUpdate()
    {
        //必要な変数
        unitychanAnimHash = game_CNTRL.unitychanAnimHash;
        if(unitychanAnimHash != WaitStateHash)
        {
            TimerUpdate();
        }

    }

    void TimerReset()
    {
        elapsedTime = 0f;
        minute = Math.Floor(elapsedTime / 60);
        hour = Math.Floor(minute / 60);
        second = elapsedTime % 60;
        elapsedTimeText = hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
        timerTextObj.GetComponent<TextMesh>().text = elapsedTimeText;
    }
    void TimerUpdate()
    {
        //基本はWait状態からRun状態になったら
        elapsedTime += Time.deltaTime;
        game_CNTRL.ClearTime = elapsedTime;
        minute = Math.Floor(elapsedTime / 60);
        hour = Math.Floor(minute / 60);
        second = elapsedTime % 60;
        elapsedTimeText = hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");
        timerTextObj.GetComponent<TextMesh>().text = elapsedTimeText;
    }

}
