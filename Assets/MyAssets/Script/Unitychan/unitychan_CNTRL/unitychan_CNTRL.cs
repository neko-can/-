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
    [HideInInspector] public int RunStateHash;
    [HideInInspector] public int JumpStateHash;
    int unitychanAnimHash;
    int previousHash;
    [HideInInspector] public float unitychanAnimTime;
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

        //処理
        Unitychan_Initializer.MyStart();
        unitychan_Forward.MyStart();
        unitychan_Move.MyStart();
        jumpPhase.MyStart();

        //初期の動き
    }

    // Update is called once per frame
    void Update () {

        //Debug.Log(Vector3.SignedAngle(unitychan.transform.forward, new Vector3(MainCamera.transform.forward.x, 0, MainCamera.transform.forward.z), new Vector3(0, 1, 0)));

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
        //変数用意
        currentAnimInfo = unitychan_Anim.GetCurrentAnimatorStateInfo(0);
        unitychanAnimHash = currentAnimInfo.fullPathHash;
        unitychanAnimTime = currentAnimInfo.normalizedTime;
        //MyUpdate()
        if (unitychanAnimHash == RunStateHash)
        {
            unitychan_Move.MyUpdate();
        }
        else if(unitychanAnimHash == JumpStateHash)
        {
            jumpPhase.MyUpdate();

        }

        if(unitychanAnimHash != previousHash)
        {
            //OnEnd()
            if(previousHash == JumpStateHash)
            {
                jumpPhase.OnEnd();
            }
            //OnChanged()
            if(unitychanAnimHash == JumpStateHash)
            {
                jumpPhase.OnChanged();
            }
            previousHash = unitychanAnimHash;
        }

    }

    void Turn()
    {
    }

    void Jump()
    {
    }
}
