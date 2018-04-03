using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public class testUnitychan_CNTRL : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・unitychanの動きのPhaseだけ追う
    /// </summary>

    //必要な変数
    //souce
    [HideInInspector] public CNTRLs cntrls;
    //script
    [HideInInspector] public testUnitychan_forward unitychan_Forward;
    [HideInInspector] public testUnitychanCollider unitychanCollider;
    //phase
    testUnitychan_Initializer Unitychan_Initializer;
    testJumpPhase jumpPhase;
    testWallKickPhase wallKickPhase;
    testWaitPhase waitPhase;
    testRunPhase runPhase;
    //variable
    [HideInInspector] public GameObject unitychan;
    [HideInInspector] public Animator unitychan_Anim;
    [HideInInspector] public Rigidbody unitychanRb;
    [HideInInspector] public GameObject MainCamera;
    //Animator
    [HideInInspector] public string BaseLayerName = "Base Layer";
    AnimatorStateInfo currentAnimInfo;
    [HideInInspector] public string RunName = "Run";
    [HideInInspector] public string WaitName = "Wait";
    [HideInInspector] public int RunStateHash;
    [HideInInspector] public int WaitStateHash;
    int unitychanAnimHash;
    int previousHash;
    [HideInInspector] public float unitychanAnimTime;
    //Jump
    [HideInInspector] public string ChargeUpName = "ChargeUp";
    [HideInInspector] public string LandingName = "Landing";
    [HideInInspector] public string ReleaseName = "Release";
    [HideInInspector] public string InAirName = "InAir";
    [HideInInspector] public int ChargeUpHash;
    [HideInInspector] public int LandingHash;
    [HideInInspector] public int ReleaseHash;
    [HideInInspector] public int InAirHash;
    //その他
    [HideInInspector] public KeyCode? downKeyCode;
    [HideInInspector] public Vector3 unitychanVelocity;
    [HideInInspector] public GameObject rayColliderObject = null;
    [HideInInspector] public float jumpTime;
    [HideInInspector] public bool IsWallHit;
    [HideInInspector] public bool IsFloorHit;
    [HideInInspector] public GameObject otherCollider;
    [HideInInspector] public Vector3? contactPoint;
    //Android用
    [HideInInspector] public int touchCount;
    Touch[] touches;
    [HideInInspector] public Touch nowTouch;
    //parameter
    [HideInInspector] public float jumpMaxHeightTime = 0.3f;
    [HideInInspector] public float jumpStartTime = 0.2f;
    [HideInInspector] public float jumpEndTime = 0.701f;

    // Use this for initialization
    void Start()
    {
        //必要な変数
        Unitychan_Initializer = GetComponent<testUnitychan_Initializer>();
        jumpPhase = GetComponent<testJumpPhase>();
        //wallKickPhase = GetComponent<testWallKickPhase>();
        waitPhase = GetComponent<testWaitPhase>();
        runPhase = GetComponent<testRunPhase>();

        //処理
        Unitychan_Initializer.MyStart();
        unitychan_Forward.MyStart();
        jumpPhase.MyStart();
        //wallKickPhase.MyStart();
        waitPhase.MyStart();
        runPhase.MyStart();

    }

    // Update is called once per frame
    void Update()
    {
        //変数用意
        currentAnimInfo = unitychan_Anim.GetCurrentAnimatorStateInfo(0);
        unitychanAnimHash = currentAnimInfo.fullPathHash;
        unitychanAnimTime = currentAnimInfo.normalizedTime;
        downKeyCode = GetKeyDownCode.getKeyDownCode();
        touchCount = Input.touchCount;
        if (touchCount > 0)
        {
            touches = Input.touches;
            nowTouch = touches[touchCount - 1];
        }

        //衝突判定
        IsWallHit = unitychanCollider.IsWallHit;
        IsFloorHit = unitychanCollider.IsFloorHit;
        contactPoint = unitychanCollider.contactPoint;
        otherCollider = unitychanCollider.otherCllider;
        unitychanCollider.MyUpdate(); //変数リセット。OnCollision系が先に実行される

        //Script制御(ScriptのPhase遷移)
        if (unitychanAnimHash != previousHash)
        {
            //OnEnd()
            if (previousHash == WaitStateHash)
            {
            }
            else if (previousHash == RunStateHash)
            {
            }
            //Jump
            else if (previousHash == ChargeUpHash)
            {

            }
            else if (previousHash == InAirHash)
            {

            }
            else if (previousHash == LandingHash)
            {

            }
            else if (previousHash == ReleaseHash)
            {

            }

            //OnChanged()
            if (unitychanAnimHash == WaitStateHash)
            {
            }
            else if (unitychanAnimHash == RunStateHash)
            {
                runPhase.OnChanged();
            }
            //Jump
            else if (unitychanAnimHash == ChargeUpHash)
            {
                jumpPhase.ChargeUpOnChanged();
            }
            else if (unitychanAnimHash == InAirHash)
            {
                jumpPhase.InAirOnChanged();
            }
            else if (unitychanAnimHash == LandingHash)
            {
                jumpPhase.LandingOnChanged();
            }
            else if (unitychanAnimHash == ReleaseHash)
            {
                jumpPhase.ReleaseOnChanged();
            }
            //
            previousHash = unitychanAnimHash;
        }

        //MyUpdate()
        if (unitychanAnimHash == WaitStateHash)
        {
            //Debug.Log(WaitName);
            waitPhase.MyUpdate();
        }
        else if (unitychanAnimHash == RunStateHash)
        {
            //Debug.Log(RunName);
            runPhase.MyUpdate();
        }
        //Jump
        else if (unitychanAnimHash == ChargeUpHash)
        {
            //Debug.Log(ChargeUpName);
            jumpPhase.ChargeUpUpdate();
        }
        else if (unitychanAnimHash == InAirHash)
        {
            //Debug.Log(InAirName);
            jumpPhase.InAirUpdate();
        }
        else if (unitychanAnimHash == LandingHash)
        {
            //Debug.Log(LandingName);
            jumpPhase.LandingUpdate();
        }
        else if (unitychanAnimHash == ReleaseHash)
        {
            //Debug.Log(ReleaseName);
            jumpPhase.ReleaseUpdate();
        }
    }

}
