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
    [HideInInspector] public GameObject GoalEnterObj;
    [HideInInspector] public bool IsOnEnterGoalArea;
    [HideInInspector] public Animator unitychanAnim;
    //script
    testGame_CNTRL_Initializer Game_CNTRL_Initializer;
    [HideInInspector] public DeadArea deadArea;
    [HideInInspector] public GoalArea goalArea;
    testGameAdvance gameAdvance;
    testTimer timer;
    ToPushButton toPushButton;
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
        timer = GetComponent<testTimer>();
        toPushButton = GetComponent<ToPushButton>();
        gameAdvance.MyStart();
        startPhase.MyStart();
        timer.MyStart();
        toPushButton.MyStart();
    }

    private void Update()
    {
        //衝突判定
        //DeadArea
        DeadEnterObj = deadArea.DeadEnterObj;
        IsOnEnterDeadArea = deadArea.IsOnEnterDeadArea;
        deadArea.MyUpdate();
        //GoalArea
        GoalEnterObj = goalArea.GoalEnterObj;
        IsOnEnterGoalArea = goalArea.IsOnEnterGoalArea;
        goalArea.MyUpdate();

        //処理
        gameAdvance.MyUpdate();
        timer.MyUpdate();
        toPushButton.MyUpdate();
    }

}
