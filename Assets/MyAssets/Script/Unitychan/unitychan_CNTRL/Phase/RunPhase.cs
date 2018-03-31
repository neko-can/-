using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunPhase : MonoBehaviour {

    unitychan_CNTRL Unitychan_CNTRL;
    Unitychan_forward unitychan_Forward;
    Animator UnitychanAnim;
    GameObject unitychan;
    KeyCode? downKeyCode;
    Vector3 unitychanVelocity;
    Rigidbody unitychanRb;
    Transform unitychanTf;
    //parameter
    float runningSpeed = 5f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychan_Forward = Unitychan_CNTRL.unitychan_Forward;
        UnitychanAnim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        unitychanTf = unitychan.transform;
    }
    public void MyUpdate()
    {
        downKeyCode = Unitychan_CNTRL.downKeyCode;

        //速度設定(重力による速度を打ち消さないようにする)
        unitychanVelocity = unitychanRb.velocity;
        unitychanVelocity.x = unitychanTf.forward.x * runningSpeed;
        unitychanVelocity.z = unitychanTf.forward.z * runningSpeed;
        unitychanRb.velocity = unitychanVelocity;

        //向き設定
        unitychan_Forward.MyUpdate();
        
        //遷移条件
        if(downKeyCode == KeyCode.Alpha1)
        {
            UnitychanAnim.SetTrigger("Jump");
        }
    }

    public void OnChanged()
    {
    }
}
