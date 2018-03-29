using System.Collections;
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
    //script
    unitychan_Initializer Unitychan_Initializer;
    [HideInInspector] public Unitychan_forward unitychan_Forward;
    [HideInInspector] public Unitychan_Move unitychan_Move;
    JumpPhase jumpPhase;
    [HideInInspector] public UnitychanCollider unitychanCollider;
    WallKickPhase wallKickPhase;
    //variable
    [HideInInspector] public GameObject unitychan;
    [HideInInspector] public Animator unitychan_Anim;
    [HideInInspector] public GameObject MainCamera;
    [HideInInspector] public float timeCount;
    AnimatorStateInfo currentAnimInfo;
    [HideInInspector] public int RunStateHash;
    [HideInInspector] public int JumpStateHash;
    [HideInInspector] public int LangingStateHash;
    int unitychanAnimHash;
    int previousHash;
    [HideInInspector] public float unitychanAnimTime;
    KeyCode? downKeyCode;
    //phase
    public MovePhase movePhase;

    //parameters
    public float runningSpeed = 13f;
    float stopTurnTime = 2f;

    // Use this for initialization
    void Start () {
        //必要な変数
        Unitychan_Initializer = GetComponent<unitychan_Initializer>();
        unitychan_Forward = GetComponent<Unitychan_forward>();
        unitychan_Move = GetComponent<Unitychan_Move>();
        jumpPhase = GetComponent<JumpPhase>();
        wallKickPhase = GetComponent<WallKickPhase>();

        //処理
        Unitychan_Initializer.MyStart();
        unitychan_Forward.MyStart();
        unitychan_Move.MyStart();
        jumpPhase.MyStart();
        wallKickPhase.MyStart();

        //初期の動き
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

        //Animator制御(AnimatorのPhase遷移)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            unitychan_Anim.SetTrigger("Run");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            unitychan_Anim.SetTrigger("Jump");
        }

        //Script制御(ScriptのPhase遷移)
        if (unitychanAnimHash != previousHash)
        {
            //OnEnd()
            if (previousHash == JumpStateHash)
            {
                jumpPhase.OnEnd();
            }
            //OnChanged()
            if (unitychanAnimHash == JumpStateHash)
            {
                jumpPhase.OnChanged();
            }
            if (unitychanAnimHash == LangingStateHash)
            {
                wallKickPhase.FirstJumpOnChanged();
            }
            previousHash = unitychanAnimHash;
        }
        //MyUpdate()
        if (unitychanAnimHash == RunStateHash)
        {
            unitychan_Move.MyUpdate();
        }
        else if(unitychanAnimHash == JumpStateHash)
        {
            jumpPhase.MyUpdate();

        }
        else if(unitychanAnimHash == LangingStateHash)
        {
            wallKickPhase.FirstJumpUpdate();
        }


    }

    void Turn()
    {
    }

    void Jump()
    {
    }
}
