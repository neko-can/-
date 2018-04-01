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
    bool IsOnEndJump = true;
    float unitychanAnimTime;
    float jumpStartTime;
    float jumpEndTime;
    Vector3 unitychanVelocity;
    GameObject rayColliderObject;
    float angleAxisX;
    float angularSpeedAxisX;
    Vector3 rotateAxisX;
    KeyCode? downKeyCode;
    float jumpMaxHeightTime;
    float jumpTime;
    float firstJumpTime;
    Vector3 jumpMaxPosition;
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
        jumpMaxHeightTime = Unitychan_CNTRL.jumpMaxHeightTime;
        jumpStartTime = Unitychan_CNTRL.jumpStartTime;
        jumpEndTime = Unitychan_CNTRL.jumpEndTime;
    }

    //FirstJump
    public void FirstJumpUpdate()
    {
        downKeyCode = Unitychan_CNTRL.downKeyCode;
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;

        if (jumpStartTime < unitychanAnimTime && unitychanAnimTime < jumpEndTime)
        {
            if (IsOnJump)
            {
                IsOnJump = false;
                unitychanRb.velocity = unitychanVelocity;
            }

            unitychan.transform.Rotate(rotateAxisX, angularSpeedAxisX * Time.deltaTime, Space.World);
            Debug.Log(Vector3.SignedAngle(unitychan.transform.up, rayColliderObject.transform.forward, new Vector3(1, 0, 0)));
        }
        
        if (IsOnEndJump && unitychanAnimTime > jumpEndTime)
        {
            IsOnEndJump = false;
            unitychanAnim.enabled = false;
        }
        if(unitychanAnimTime > jumpMaxHeightTime)
        {
            jumpMaxPosition = unitychan.transform.position;
            unitychan.transform.position = jumpMaxPosition;
            //unitychanRb.constraints = RigidbodyConstraints.FreezePosition;
        }

        //2ndJumpへ
        if(downKeyCode == KeyCode.Alpha1)
        {
            unitychanAnim.enabled = true;
        }

    }
    public void FirstJumpOnChanged()
    {
        //必要な変数
        unitychanVelocity = Unitychan_CNTRL.unitychanVelocity;
        rayColliderObject = Unitychan_CNTRL.rayColliderObject;
        angleAxisX = Vector3.SignedAngle(unitychan.transform.up, -rayColliderObject.transform.forward, new Vector3(1, 0, 0));
        jumpTime = Unitychan_CNTRL.jumpTime;
        firstJumpTime = (jumpEndTime - jumpStartTime) * jumpTime;
        angularSpeedAxisX = -angleAxisX / firstJumpTime;
        rotateAxisX = unitychan.transform.right;
    }
    public void FirstJumpOnEnd()
    {
        IsOnJump = true;
        IsOnEndJump = true;
    }
    public void SecondJumpUpdate()
    {
    }
    public void SecondJumpOnChanged()
    {

    }

}
