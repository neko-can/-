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
    Vector3 AddLocalVelocity;
    Vector3 rayContactPoint;
    bool IsFloorHit;
    bool IsWallHit;
    bool IsWallKick = false;
    bool IsEndWallKick = false;
    bool previouseKick = false;
    float jumpElapsedTime;
    float stopPosMinNormTime = 0.4f;
    float rayStopNormTime = 0.5f;
    //parameter
    float firstVelocityY = 3f;
    float firstVelocityF = 5f;
    float wallKickVelocityF = 3f;
    float wallKickVelocityUp = 1f;
    float wallKickMaxTime = 0.5f;

    public void MyStart()
    {
        Unitychan_CNTRL = GetComponent<testUnitychan_CNTRL>();
        unitychan_Anim = Unitychan_CNTRL.unitychan_Anim;
        unitychan = Unitychan_CNTRL.unitychan;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        unitychanCollider = Unitychan_CNTRL.unitychanCollider;
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
        if (IsWallKick)
        {
            //unitychan.transform.up = rayOtherObject.transform.forward;
            unitychanRb.velocity = Vector3.zero;
            unitychan_Anim.enabled = false;
        }
        
        //Debug.Log("ReleaseTrigger");

    }
    public void ChargeUpUpdate()
    {
        unitychanAnimTime = Unitychan_CNTRL.unitychanAnimTime;
        downKeyCode = Unitychan_CNTRL.downKeyCode;
        if (IsWallKick)
        {
            unitychanRb.AddForce(-unitychan.transform.up * 10f);
            //unitychanRb.AddForce((rayContactPoint - unitychan.transform.position) * 10f);
            if (downKeyCode == KeyCode.Alpha1)
            {
                unitychan_Anim.enabled = true;
            }
            if(Unitychan_CNTRL.touchCount > 0 && Unitychan_CNTRL.nowTouch.phase == TouchPhase.Began)
            {
                unitychan_Anim.enabled = true;
            }
            if (Input.GetMouseButtonDown(0))
            {
                unitychan_Anim.enabled = true;
            }
        }
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
        AddVelocity = AddWallKickJump(); //加える速度の初期値
        ToWallKick(); //WallKickやるか計算

        if (IsWallKick)
        {
            unitychanRb.useGravity = false;
            unitychanRb.velocity = AddVelocity;
            //unitychan.transform.up = rayOtherObject.transform.forward;
            unitychan_Anim.SetTrigger(ChargeUpTrigger);
        }
        else
        {
            unitychanRb.useGravity = true;
            unitychanRb.velocity = AddNormalJump();
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
        IsWallHit = Unitychan_CNTRL.IsWallHit;
        otherObject = Unitychan_CNTRL.otherCollider;
        if (IsWallKick)
        {
            if (IsFloorHit)
            {
                //unitychan.transform.up = otherObject.transform.up;
            }
            if (IsWallHit)
            {
                Debug.Log(rayOtherObject.transform.forward);
                unitychan.transform.up = rayOtherObject.transform.forward;
                unitychan_Anim.enabled = true;
            }
        }
        else
        {
            if (IsFloorHit)
            {
                if (unitychan_Anim.enabled == false)
                {
                    unitychan_Anim.enabled = true;
                }
                //Debug.Log("RunTrigger");
            }
        }

    }

    public Vector3 AddNormalJump()
    {
        AddLocalVelocity = unitychanRb.velocity;
        //AddLocalVelocity += unitychan.transform.forward * firstVelocityF + new Vector3(0, firstVelocityY);
        //AddLocalVelocity += new Vector3(MainCamera.transform.forward.x, 0, MainCamera.transform.forward.z) * firstVelocityF + MainCamera.transform.up * firstVelocityY;
        AddLocalVelocity += MainCamera.transform.forward * firstVelocityF;

        jumpFullTime = Mathf.Abs(2 * AddLocalVelocity.y / Physics.gravity.y);
        return AddLocalVelocity;
    }

    public Vector3 AddWallKickJump()
    {
        //AddLocalVelocity = MainCamera.transform.forward * wallKickVelocityF + MainCamera.transform.up * wallKickVelocityUp;
        //AddLocalVelocity = new Vector3(MainCamera.transform.forward.x, 0, MainCamera.transform.forward.z) * wallKickVelocityF + MainCamera.transform.up * wallKickVelocityUp;
        AddLocalVelocity = MainCamera.transform.forward * wallKickVelocityF;

        return AddLocalVelocity;
    }

    public void ToWallKick()
    {
        //初期値設定
        IsWallKick = false;
        IsEndWallKick = false;
        rayOtherObject = null;
        rayStartPos = unitychan.transform.position;
        rayPos = rayStartPos;
        rayPos += AddVelocity * wallKickMaxTime;
        //rayPos.y += 0.5f * Physics.gravity.y * Mathf.Pow(rayStopNormTime * jumpFullTime, 2);
        ray = new Ray(rayStartPos, rayPos - rayStartPos);

        if (Physics.Raycast(ray, out raycastHit, Vector3.Distance(rayPos, rayStartPos)))
        {
            Debug.Log(raycastHit.collider.name);
            if(raycastHit.collider.gameObject.transform.parent.name == "Walls")
            {
                rayOtherObject = raycastHit.collider.gameObject;
                IsWallKick = true;
                //Debug.Log("RayHit");
                Debug.Log(rayOtherObject.name);
                rayPreviousObject = rayOtherObject;
                rayContactPoint = raycastHit.point;
            }
        }
        if(previouseKick == true && IsWallKick == false)
        {
            IsEndWallKick = true;
        }
        previouseKick = IsWallKick;

        //rayの視覚化
        //rayClone = GameObject.Instantiate(rayObject);
        //rayClone.transform.position = rayPos;
    }
}
