using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_CNTRL_Initializer : MonoBehaviour {

    game_CNTRL Game_CNTRL;

    public void Initialize()
    {
        Game_CNTRL = GetComponent<game_CNTRL>();
        Game_CNTRL.cntrls = transform.parent.gameObject.GetComponent<CNTRLs>();
        Game_CNTRL.unitychan = Game_CNTRL.cntrls.unitychan;
        Debug.Log(Game_CNTRL.MapInScene.name);
        Game_CNTRL.startPoint = Game_CNTRL.MapInScene.transform.Find("Pointers/StartArea").gameObject;
        Game_CNTRL.StartPointDirection = Game_CNTRL.MapInScene.transform.Find("Pointers/StartDirection").gameObject;
        Game_CNTRL.MainCamera = GameObject.Find("Player/Main Camera");
        Game_CNTRL.Player = GameObject.Find("Player");
    }
}
