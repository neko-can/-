using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGame_CNTRL_Initializer : MonoBehaviour {

    testGame_CNTRL Game_CNTRL;

    public void Initialize()
    {
        Game_CNTRL = GetComponent<testGame_CNTRL>();
        Game_CNTRL.cntrls = transform.parent.gameObject.GetComponent<CNTRLs>();
        Game_CNTRL.unitychan = Game_CNTRL.cntrls.unitychan;
        Game_CNTRL.startPoint = Game_CNTRL.MapInScene.transform.Find("Pointers/StartArea").gameObject;
        Game_CNTRL.StartPointDirection = Game_CNTRL.MapInScene.transform.Find("Pointers/StartDirection").gameObject;
        Game_CNTRL.MainCamera = GameObject.Find("Player/Main Camera");
        Game_CNTRL.Player = GameObject.Find("Player");
        Game_CNTRL.deadArea = Game_CNTRL.MapInScene.transform.Find("Pointers/DeadArea").GetComponent<DeadArea>();
    }
}
