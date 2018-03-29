using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitPhase : MonoBehaviour {

    //必要な変数
    unitychan_CNTRL Unitychan_CNTRL;
    KeyCode? downKeyCode;
    Animator unitychanAnim;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
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
    }

}
