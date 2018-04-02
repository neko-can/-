using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testRunPhase : MonoBehaviour {

    testUnitychan_CNTRL Unitychan_CNTRL;
    Animator UnitychanAnim;
    GameObject unitychan;
    KeyCode? downKeyCode;
    Vector3 unitychanVelocity;
    Rigidbody unitychanRb;
    Transform unitychanTf;
    string jumpTrigger;
    GameObject otherObject;
    //parameter
    float runningSpeed = 5f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<testUnitychan_CNTRL>();
        UnitychanAnim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        unitychanTf = unitychan.transform;
        jumpTrigger = Unitychan_CNTRL.ChargeUpName;
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
        Unitychan_CNTRL.unitychan_Forward.MyUpdate();
        
        //遷移条件
        if(downKeyCode == KeyCode.Alpha1)
        {
            Debug.Log("RunToJump");
            UnitychanAnim.SetTrigger(jumpTrigger);
        }
        if(Unitychan_CNTRL.touchCount > 0 && Unitychan_CNTRL.nowTouch.phase == TouchPhase.Began)
        {
            UnitychanAnim.SetTrigger(jumpTrigger);
        }
        if (Input.GetMouseButtonDown(0))
        {
            UnitychanAnim.SetTrigger(jumpTrigger);
        }
    }

    public void OnChanged()
    {
        otherObject = Unitychan_CNTRL.otherCollider;
        if(unitychan.transform.up != otherObject.transform.up)
        {
            unitychan.transform.up = otherObject.transform.up;
        }
    }
}
