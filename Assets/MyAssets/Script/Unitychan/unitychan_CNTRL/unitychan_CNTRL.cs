﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using unityHelper;

public delegate void MovePhase();
public class unitychan_CNTRL : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・unitychanの動きのPhaseだけ追う
    /// </summary>

    //必要な変数
    //souce
    [HideInInspector] public CNTRLs cntrls;
    //script
    [HideInInspector] public Unitychan_forward unitychan_Forward;
    [HideInInspector] public UnitychanCollider unitychanCollider;
    //phase
    unitychan_Initializer Unitychan_Initializer;
    JumpPhase jumpPhase;
    WallKickPhase wallKickPhase;
    WaitPhase waitPhase;
    RunPhase runPhase;
    //variable
    [HideInInspector] public GameObject unitychan;
    [HideInInspector] public Animator unitychan_Anim;
    [HideInInspector] public Rigidbody unitychanRb;
    [HideInInspector] public GameObject MainCamera;
    [HideInInspector] public float timeCount;
    AnimatorStateInfo currentAnimInfo;
    [HideInInspector] public int RunStateHash;
    [HideInInspector] public int JumpStateHash;
    [HideInInspector] public int LandingStateHash;
    [HideInInspector] public int WaitStateHash;
    int unitychanAnimHash;
    int previousHash;
    [HideInInspector] public float unitychanAnimTime;
    [HideInInspector] public KeyCode? downKeyCode;
    [HideInInspector] public Vector3 unitychanVelocity;
    [HideInInspector] public GameObject rayColliderObject = null;
    [HideInInspector] public float jumpTime;
    [HideInInspector] public bool IsHit;
    //parameter
    [HideInInspector] public float jumpMaxHeightTime = 0.3f;
    [HideInInspector] public float jumpStartTime = 0.2f;
    [HideInInspector] public float jumpEndTime = 0.701f;

    // Use this for initialization
    void Start () {
        //必要な変数
        Unitychan_Initializer = GetComponent<unitychan_Initializer>();
        jumpPhase = GetComponent<JumpPhase>();
        wallKickPhase = GetComponent<WallKickPhase>();
        waitPhase = GetComponent<WaitPhase>();
        runPhase = GetComponent<RunPhase>();

        //処理
        Unitychan_Initializer.MyStart();
        unitychan_Forward.MyStart();
        jumpPhase.MyStart();
        wallKickPhase.MyStart();
        waitPhase.MyStart();
        runPhase.MyStart();

    }

    // Update is called once per frame
    void Update () {
        //変数用意
        currentAnimInfo = unitychan_Anim.GetCurrentAnimatorStateInfo(0);
        unitychanAnimHash = currentAnimInfo.fullPathHash;
        unitychanAnimTime = currentAnimInfo.normalizedTime;
        downKeyCode = GetKeyDownCode.getKeyDownCode();
        //衝突判定
        unitychanCollider.MyUpdate();
        IsHit = unitychanCollider.IsHit;

        //Script制御(ScriptのPhase遷移)
        if (unitychanAnimHash != previousHash)
        {
            //OnEnd()
            if (previousHash == JumpStateHash)
            {
                jumpPhase.OnEnd();
            }
            else if(previousHash == LandingStateHash)
            {
                wallKickPhase.FirstJumpOnEnd();
            }
            else if(previousHash == RunStateHash)
            {

            }
            else if(previousHash == WaitStateHash)
            {

            }

            //OnChanged()
            if (unitychanAnimHash == JumpStateHash)
            {
                jumpPhase.OnChanged();
            }
            else if (unitychanAnimHash == LandingStateHash)
            {
                wallKickPhase.FirstJumpOnChanged();
            }
            else if(previousHash == RunStateHash)
            {

            }
            else if(previousHash == WaitStateHash)
            {

            }
            //
            previousHash = unitychanAnimHash;
        }

        //MyUpdate()
        if (unitychanAnimHash == JumpStateHash)
        {
            jumpPhase.MyUpdate();
        }
        else if(unitychanAnimHash == LandingStateHash)
        {
            wallKickPhase.FirstJumpUpdate();
        }
        else if(unitychanAnimHash == RunStateHash)
        {
            runPhase.MyUpdate();
        }
        else if(unitychanAnimHash == WaitStateHash)
        {
            waitPhase.MyUpdate();
        }


    }

    void Turn()
    {
    }

    void Jump()
    {
    }
}
