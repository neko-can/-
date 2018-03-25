using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitychan_Move : MonoBehaviour {

    //必要な変数
    //script
    unitychan_CNTRL Unitychan_CNTRL;
    Unitychan_forward unitychan_Forward;
    //variable
    Animator unitychan_Anim;
    float baseSpeed = 6f;
    GameObject unitychan;

    //parameter
    float stopDuringTurn = 3f;

    public void MyStart()
    {
        //必要な変数
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Forward = Unitychan_CNTRL.unitychan_Forward;
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
    }
    public void MyUpdate()
    {
        //速度設定
        //unitychan.transform.Translate(unitychan.transform.forward * Time.deltaTime * Unitychan_CNTRL.runningSpeed);
        unitychan.GetComponent<Rigidbody>().velocity = unitychan.transform.forward * Unitychan_CNTRL.runningSpeed;
        //向き設定
        unitychan_Forward.MyUpdate();
    }
    public void MyLaterUpdate()
    {
        //unitychan_Anim.SetFloat("Speed", baseSpeed);
    }

}
