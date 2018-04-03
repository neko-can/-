using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public class testStartPhase : MonoBehaviour {

    //ソース
    testGame_CNTRL Game_CNTRL;
    //必要な変数
    GameObject unitychan;
    GameObject startPoint;
    GameObject StartPointDirection;
    GameObject MainCamera;
    GameObject Player;

    public void MyStart()
    {
        //必要な変数
        Game_CNTRL = GetComponent<testGame_CNTRL>();
        unitychan = Game_CNTRL.unitychan;
        startPoint = Game_CNTRL.startPoint;
        StartPointDirection = Game_CNTRL.StartPointDirection;
        MainCamera = Game_CNTRL.MainCamera;
        Player = Game_CNTRL.Player;

        //処理
        unitychan.transform.position = startPoint.transform.position;
        Player.transform.forward = StartPointDirection.transform.forward;
        unitychan.transform.forward = StartPointDirection.transform.forward;
    }

    public void MyUpdate()
    {

    }
}
