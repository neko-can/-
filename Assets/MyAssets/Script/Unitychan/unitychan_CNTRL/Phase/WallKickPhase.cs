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
    Vector3? contactPoint;
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
    float angleRight;
    float angleUp;
    float angularSpeedRight;
    float angularSpeedUp;
    Vector3 rotateRight;
    Vector3 rotateUp;
    KeyCode? downKeyCode;
    float jumpMaxHeightTime;
    float jumpTime;
    Vector3 jumpMaxPosition;
    bool IsWallHit;
    //ver2
    float newNormAnimTime;
    Vector3 startUp;
    Vector3 goalF;
    //ver3
    float eularX;
    float eularY;
    float eularZ;
    Vector3 Eular;
    Quaternion startQ;
    //ver4
    Vector3 EularRight;

    Vector3 forceDirection;
    float forceMagni = 100f;

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
        IsWallHit = Unitychan_CNTRL.IsWallHit;

        //飛んでいる時間
        if (jumpStartTime < unitychanAnimTime && unitychanAnimTime < jumpEndTime)
        {
            //初速度付与
            if (IsOnJump)
            {
                IsOnJump = false;
                unitychanRb.velocity = unitychanVelocity;
            }
            newNormAnimTime = (unitychanAnimTime - jumpStartTime) / (jumpEndTime - jumpStartTime);
            //角度調整
            //unitychan.transform.Rotate(rotateRight, angularSpeedRight * Time.deltaTime, Space.World);
            //unitychan.transform.Rotate(new Vector3(1, 0, 0), angularSpeedRight * Time.deltaTime, Space.Self);
            //Debug.Log(Vector3.SignedAngle(unitychan.transform.up, rayColliderObject.transform.forward, rotateRight));
            //unitychan.transform.Rotate(new Vector3(0, 1, 0), angularSpeedUp * Time.deltaTime, Space.Self);
            //unitychan.transform.Rotate(rotateUp, angularSpeedUp * Time.deltaTime, Space.World);

            //ver2
            //unitychan.transform.up = goalF * newNormAnimTime + startUp * (1 - newNormAnimTime);

            //ver3
            //unitychan.transform.rotation = Quaternion.Euler(startQ.eulerAngles - Eular * newNormAnimTime);

            //ver4
            //unitychan.transform.rotation = Quaternion.Euler(startQ.eulerAngles - Eular * newNormAnimTime + EularRight * newNormAnimTime);
        }

        //ジャンプ終了後（本当は要らない）
        if (IsOnEndJump && unitychanAnimTime > jumpEndTime)
        {
            IsOnEndJump = false;
            unitychanAnim.enabled = false;
        }
        if (IsWallHit && unitychanAnimTime > 0.3f)
        {
            contactPoint = Unitychan_CNTRL.contactPoint;
            Debug.Log(contactPoint);
            unitychanRb.useGravity = false;
            unitychanRb.velocity = Vector3.zero;
            unitychan.transform.up = rayColliderObject.transform.forward;
        }
        if(unitychanAnimTime > jumpEndTime)
        {
            unitychanRb.AddForce(((Vector3)contactPoint - unitychan.transform.position) * 10f);
        }

        //2ndJumpへ
        if(downKeyCode == KeyCode.Alpha1)
        {
            unitychanAnim.enabled = true;
            unitychanAnim.SetTrigger("SecondJump");
        }
    }
    public void FirstJumpOnChanged()
    {
        //必要な変数
        unitychanVelocity = Unitychan_CNTRL.unitychanVelocity;
        rayColliderObject = Unitychan_CNTRL.rayColliderObject;
        angleRight = Vector3.SignedAngle(unitychan.transform.up, rayColliderObject.transform.forward, unitychan.transform.right);
        Debug.Log(angleRight.ToString());
        jumpTime = Unitychan_CNTRL.jumpTime; //空中に浮いている時間
        angularSpeedRight = -angleRight / jumpTime;
        rotateRight = unitychan.transform.right;

        angleUp = Vector3.SignedAngle(unitychan.transform.forward, rayColliderObject.transform.forward, unitychan.transform.up);
        angularSpeedUp = -angleUp / jumpTime;
        rotateUp = unitychan.transform.up;
        Debug.Log(angleUp.ToString());

        //ver2
        //startUp = unitychan.transform.up;
        //goalF = rayColliderObject.transform.forward;

        //ver3
        //eularX = Vector3.SignedAngle(unitychan.transform.up, rayColliderObject.transform.forward, new Vector3(1, 0, 0));
        //eularY = Vector3.SignedAngle(unitychan.transform.up, rayColliderObject.transform.forward, new Vector3(0, 1, 0));
        //eularZ = Vector3.SignedAngle(unitychan.transform.up, rayColliderObject.transform.forward, new Vector3(0, 0, 1));
        //Eular = new Vector3(eularX, eularY, eularZ);
        startQ = unitychan.transform.rotation;

        //ver4
        Eular = Quaternion.FromToRotation(unitychan.transform.up, -rayColliderObject.transform.forward).eulerAngles;
        Debug.Log(rayColliderObject.transform.forward);
        //EularRight = Quaternion.FromToRotation(unitychan.transform.forward, rayColliderObject.transform.forward).eulerAngles;
        //ver5
        //Eular = Quaternion.LookRotation(-rayColliderObject.transform.up).eulerAngles;
        //EularRight = Quaternion.LookRotation(rayColliderObject.transform.forward).eulerAngles;
        Debug.Log("eularRight = " + Eular.ToString());
        Debug.Log("eularUp = " + EularRight.ToString());
    }
    public void FirstJumpOnEnd()
    {
        IsOnJump = true;
        IsOnEndJump = true;
    }
    public void SecondJumpUpdate()
    {
        if (Unitychan_CNTRL.IsFloorHit)
        {
            unitychan.transform.up = Unitychan_CNTRL.otherCollider.transform.up;
        }
    }
    public void SecondJumpOnChanged()
    {
        unitychanRb.useGravity = true;
    }

}
