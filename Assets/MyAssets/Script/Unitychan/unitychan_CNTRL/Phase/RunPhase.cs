using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPhase : MonoBehaviour {

    unitychan_CNTRL Unitychan_CNTRL;
    Unitychan_forward unitychan_Forward;
    Animator UnitychanAnim;
    GameObject unitychan;
    KeyCode? downKeyCode;
    //parameter
    float runningSpeed = 13f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Forward = Unitychan_CNTRL.unitychan_Forward;
        UnitychanAnim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
    }
    public void MyUpdate()
    {
        //速度設定
        downKeyCode = Unitychan_CNTRL.downKeyCode;
        unitychan.GetComponent<Rigidbody>().velocity = unitychan.transform.forward * runningSpeed;
        //向き設定
        unitychan_Forward.MyUpdate();
        
        //遷移条件
        if(downKeyCode == KeyCode.Alpha2)
        {
            UnitychanAnim.SetTrigger("Jump");
        }
    }
}
