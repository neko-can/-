using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testWaitPhase : MonoBehaviour {

    //必要な変数
    testUnitychan_CNTRL Unitychan_CNTRL;
    KeyCode? downKeyCode;
    Animator unitychanAnim;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<testUnitychan_CNTRL>();
        unitychanAnim = Unitychan_CNTRL.unitychan_Anim;
    }

    public void MyUpdate()
    {
        //必要な変数
        downKeyCode = Unitychan_CNTRL.downKeyCode;

        if (downKeyCode == KeyCode.Alpha1)
        {
            unitychanAnim.SetTrigger("Run");
        }
        if(Unitychan_CNTRL.touchCount>0&&Unitychan_CNTRL.nowTouch.phase == TouchPhase.Began)
        {
            unitychanAnim.SetTrigger("Run");
        }
        if (Input.GetMouseButtonDown(0))
        {
            unitychanAnim.SetTrigger("Run");
        }
    }

}
