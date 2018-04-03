using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBarometer : MonoBehaviour {

    //ステージの大きさに応じてパラメータを変更する
    //CNTRL間をまたぐからCNTRLsに付与

    //source
    CNTRLs cntrls;
    //variable
    public GameObject sizeBarometer;
    Vector3 BarometerSize;
    Vector3 NewSize;
    float NewSpeed;
    float NewDistance;
    Vector2 NewFirstVelocityFU;
    Vector2 NewWallKickVelocityFU;

    public void MyStart()
    {
        cntrls = GetComponent<CNTRLs>();

        BarometerSize = sizeBarometer.transform.lossyScale;
        cntrls.unitychan.transform.localScale = BarometerSize;
    }
}
