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
    public Unitychan_forward unitychan_Forward;
    public Unitychan_Move unitychan_Move;
    JumpPhase jumpPhase;
    //variable
    public GameObject unitychan;
    public Animator unitychan_Anim;
    public GameObject MainCamera;
    public float timeCount;
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
        movePhase = new MovePhase(unitychan_Move.MyUpdate);
    }

    // Update is called once per frame
    void Update () {
        movePhase();

        //Phase遷移条件
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
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
