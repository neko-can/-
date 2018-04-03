using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_CNTRL : MonoBehaviour {

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
    //script
    game_CNTRL_Initializer Game_CNTRL_Initializer;
    [HideInInspector] public DeadArea deadArea;
    //phase
    StartPhase startPhase;


    private void Start()
    {
        //変数セット
        Game_CNTRL_Initializer = GetComponent<game_CNTRL_Initializer>();
        Game_CNTRL_Initializer.Initialize();
        //phase
        startPhase = GetComponent<StartPhase>();
        startPhase.MyStart();
    }

    private void Update()
    {
        
    }

}
