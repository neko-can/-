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
    }

    //FirstJump
    public void FirstJumpUpdate()
    {
        //unitychan.transform.position = contactPoint;
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            resetEularRotation = new Vector3(0, unitychan.transform.eulerAngles.y, unitychan.transform.eulerAngles.z);
            unitychan.transform.eulerAngles = resetEularRotation;
            unitychanRb.useGravity = true;

            unitychanAnim.SetTrigger("SecondJump");
        }
    }
    public void FirstJumpOnChanged()
    {
        //contactPoint = unitychan.transform.position;
        unitychanRb.velocity = Vector3.zero;
        unitychanRb.useGravity = false;
        otherCollider = unitychanCollider.otherCllider;

        unitychan.transform.up = otherCollider.transform.forward;
    }
    public void SecondJumpUpdate()
    {
        unitychanRb.velocity = MainCamera.transform.forward * first2ndJumpVelocity;
    }
    public void SecondJumpOnChanged()
    {

    }

}
