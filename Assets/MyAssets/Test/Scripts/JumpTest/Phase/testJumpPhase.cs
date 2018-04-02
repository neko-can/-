using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testJumpPhase : MonoBehaviour {

    //ソース
    testUnitychan_CNTRL Unitychan_CNTRL;
    WallKickHelp wallKickHelp;
    //script
    testUnitychanCollider unitychanCollider;
    //必要な変数
    Animator unitychan_Anim;
    GameObject unitychan;
    Rigidbody unitychanRb;
    Vector3 unitychanVelocity;
    bool IsOnJump = true;
    float unitychanAnimTime;
    Ray ray;
    RaycastHit raycastHit;
    Vector3 rayStartPos;
    Vector3 rayDirection;
    Vector3 rayPos;
    float jumpFullTime;
    public GameObject rayObject;
    GameObject rayClone;
    KeyCode? downKeyCode;
    GameObject rayOtherObject = null;
    GameObject rayPreviousObject = null;
    GameObject otherObject;
    //Jump
    GameObject MainCamera;
    string ReleaseTrigger;
    string InAirTrigger;
    string LandingTrigger;
    string RunTrigger;
    string ChargeUpTrigger;
    Vector3 AddVelocity;
    bool IsFloorHit;
    bool IsWallHit;
    [HideInInspector] public bool IsWallKick = false;
    float jumpElapsedTime;
    float stopPosMinNormTime = 0.4f;
    float rayStopNormTime = 0.5f;
    //parameter
    float firstVelocityY = 11f;
    float firstVelocityF = 5f;
    float wallKickVelocity = 10f;
    float jumpStartTime;
    float jumpEndTime;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<testUnitychan_CNTRL>();
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        unitychanCollider = Unitychan_CNTRL.unitychanCollider;
        jumpStartTime = Unitychan_CNTRL.jumpStartTime;
        jumpEndTime = Unitychan_CNTRL.jumpEndTime;
        ReleaseTrigger = Unitychan_CNTRL.ReleaseName;
        LandingTrigger = Unitychan_CNTRL.LandingName;
        InAirTrigger = Unitychan_CNTRL.InAirName;
        RunTrigger = Unitychan_CNTRL.RunName;
        ChargeUpTrigger = Unitychan_CNTRL.ChargeUpName;
        MainCamera = Unitychan_CNTRL.MainCamera;
    }

    //足縮めるまで
    public void ChargeUpOnChanged()
    {
        unitychanRb.useGravity = true;
        if (IsWallKick)
        {
            unitychan.transform.up = rayOtherObject.transform.forward;
            unitychanRb.useGravity = false;
            unitychanRb.velocity = Vector3.zero;
            unitychan_Anim.enabled = false;
        }
        
        //Debug.Log("ReleaseTrigger");

    }
    public void ChargeUpUpdate()
    {
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;
    }

    //足伸ばすまで
    public void ReleaseOnChanged()
    {
    }
    public void ReleaseUpdate()
    {
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;
        //Debug.Log(unitychanAnimTime);
    }

    //空中
    public void InAirOnChanged()
    {
        //必要な変数
        if (IsWallKick)
        {
            unitychanRb.velocity = AddWallKickJump();
        }
        else
        {
            unitychanRb.useGravity = true;
            unitychanRb.velocity = AddNormalJump();
        }
        jumpElapsedTime = 0f;
        //Debug.Log("LandingTrigger");

        //WallKickMotion入れるか判定
        if (ToWallKick())
        {
            unitychan_Anim.SetTrigger(ChargeUpTrigger);
        }
        else
        {
            unitychan_Anim.SetTrigger(RunTrigger);
        }
    }
    public void InAirUpdate()
    {
        //必要な変数
        jumpElapsedTime += Time.deltaTime;

    }
    
    //着地まで
    public void LandingOnChanged()
    {
        unitychan_Anim.enabled = false;
        if (IsWallKick)
        {
            //unitychan_Anim.enabled = true;
        }
    }
    public void LandingUpdate()
    {
        IsFloorHit = Unitychan_CNTRL.IsFloorHit;
        otherObject = Unitychan_CNTRL.otherCollider;

        if(IsFloorHit)
        {
            unitychan_Anim.enabled = true;
            unitychan.transform.up = otherObject.transform.up;
            //Debug.Log("RunTrigger");
        }

    }

    public Vector3 AddNormalJump()
    {
        AddVelocity = unitychanRb.velocity;
        AddVelocity += unitychan.transform.forward * firstVelocityF + new Vector3(0, firstVelocityY);

        jumpFullTime = Mathf.Abs(2 * AddVelocity.y / Physics.gravity.y);
        return AddVelocity;
    }

    public Vector3 AddWallKickJump()
    {
        AddVelocity = MainCamera.transform.forward * wallKickVelocity;

        return AddVelocity;
    }

    public bool ToWallKick()
    {
        //初期値設定
        IsWallKick = false;
        rayOtherObject = null;
        rayStartPos = unitychan.transform.position;
        rayPos = rayStartPos;
        rayPos += unitychanRb.velocity * rayStopNormTime * jumpFullTime;
        rayPos.y += 0.5f * Physics.gravity.y * Mathf.Pow(rayStopNormTime * jumpFullTime, 2);
        ray = new Ray(rayStartPos, rayPos);

        if (Physics.Raycast(ray, out raycastHit, Vector3.Distance(rayPos, rayStartPos)))
        {
            if(raycastHit.collider.gameObject.transform.parent.name == "Walls" && raycastHit.collider.gameObject != rayPreviousObject)
            {
                rayOtherObject = raycastHit.collider.gameObject;
                IsWallKick = true;
                //Debug.Log("RayHit");
                Debug.Log(rayOtherObject.name);
                rayPreviousObject = rayOtherObject;
            }
        }

        //rayの視覚化
        rayClone = GameObject.Instantiate(rayObject);
        rayClone.transform.position = rayPos;

        return IsWallKick;
    }
}
