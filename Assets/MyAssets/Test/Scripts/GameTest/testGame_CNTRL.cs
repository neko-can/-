using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGame_CNTRL : MonoBehaviour {

    //ソース
    [HideInInspector] public CNTRLs cntrls;
    //必要な変数
    [HideInInspector] public GameObject unitychan;
    public GameObject MapInScene;
    [HideInInspector]public GameObject startPoint;
    [HideInInspector]public GameObject endPoint;
    [HideInInspector]public GameObject StartPointDirection;
    [HideInInspector] public GameObject MainCamera;
    [HideInInspector] public GameObject Player;
    [HideInInspector] public GameObject DeadEnterObj;
    [HideInInspector] public bool IsOnEnterDeadArea;
    //script
    testGame_CNTRL_Initializer Game_CNTRL_Initializer;
    [HideInInspector] public DeadArea deadArea;
    testGameAdvance gameAdvance;
    //phase
    testStartPhase startPhase;


    private void Start()
    {
        //変数セット
        Game_CNTRL_Initializer = GetComponent<testGame_CNTRL_Initializer>();
        Game_CNTRL_Initializer.Initialize();
        //phase
        startPhase = GetComponent<testStartPhase>();
        gameAdvance = GetComponent<testGameAdvance>();
        gameAdvance.MyStart();
        startPhase.MyStart();
    }

    private void Update()
    {
        //衝突判定
        DeadEnterObj = deadArea.DeadEnterObj;
        IsOnEnterDeadArea = deadArea.IsOnEnterDeadArea;
        deadArea.MyUpdate();

        //処理
        gameAdvance.MyUpdate();
    }

}
