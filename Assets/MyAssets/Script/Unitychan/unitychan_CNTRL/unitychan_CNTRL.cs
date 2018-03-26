using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    //variable
    [HideInInspector] public GameObject unitychan;
    [HideInInspector] public Animator unitychan_Anim;
    [HideInInspector] public GameObject MainCamera;
    [HideInInspector] public float timeCount;
    AnimatorStateInfo currentAnimInfo;
    [HideInInspector] public int RunStateInfo;
    [HideInInspector] public int JumpStateInfo;
    //phase
    public MovePhase movePhase;

    //parameters
    public float runningSpeed = 6f;
    float stopTurnTime = 2f;

    // Use this for initialization
    void Start () {
        //必要な変数
        Unitychan_Initializer = GetComponent<unitychan_Initializer>();
        unitychan_Forward = GetComponent<Unitychan_forward>();
        unitychan_Move = GetComponent<Unitychan_Move>();
        jumpPhase = GetComponent<JumpPhase>();

        //処理
        Unitychan_Initializer.MyStart();
        unitychan_Forward.MyStart();
        unitychan_Move.MyStart();
        jumpPhase.MyStart();

        //初期の動き
    }

    // Update is called once per frame
    void Update () {

        //Animator制御 & OnChanged
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            unitychan_Anim.SetTrigger("Run");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            unitychan_Anim.SetTrigger("Jump");
        }

        //Script制御
        currentAnimInfo = unitychan_Anim.GetCurrentAnimatorStateInfo(0);
        Debug.Log(currentAnimInfo.fullPathHash);
        if (currentAnimInfo.fullPathHash == RunStateInfo)
        {
            unitychan_Move.MyUpdate();
        }
        
    }

    void Turn()
    {
    }

    void Jump()
    {
        movePhase = new MovePhase(jumpPhase.MyMain);
    }
}
