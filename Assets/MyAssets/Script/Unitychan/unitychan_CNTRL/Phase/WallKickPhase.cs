using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallKickPhase : MonoBehaviour {

    //必要な変数
    //source
    unitychan_CNTRL Unitychan_CNTRL;
    //script
    UnitychanCollider unitychanCollider;
    //variable
    Vector3 contactPoint;
    GameObject unitychan;
    Rigidbody unitychanRb;
    GameObject otherCollider;
    Animator unitychanAnim;
    GameObject MainCamera;
    Vector3 resetEularRotation;
    bool IsOnJump = true;
    float unitychanAnimTime;
    float jumpStartTime;
    //parameter
    float first2ndJumpVelocity = 10f;

    public void MyStart()
    {
        //必要な変数
        Unitychan_CNTRL = GetComponent<unitychan_CNTRL>();
        unitychanCollider = Unitychan_CNTRL.unitychanCollider;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanAnim = Unitychan_CNTRL.unitychan_Anim;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        MainCamera = Unitychan_CNTRL.MainCamera;
        jumpStartTime = Unitychan_CNTRL.jumpStartTime;
    }

    //FirstJump
    public void FirstJumpUpdate()
    {
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;

        if(IsOnJump && unitychanAnimTime > jumpStartTime)
        {

        }

        //unitychan.transform.position = contactPoint;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            unitychanAnim.SetTrigger("SecondJump");
        }

    }
    public void FirstJumpOnChanged()
    {
    }
    public void SecondJumpUpdate()
    {
    }
    public void SecondJumpOnChanged()
    {

    }

}
