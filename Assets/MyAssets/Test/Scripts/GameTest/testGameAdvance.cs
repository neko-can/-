using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testGameAdvance : MonoBehaviour {

    testGame_CNTRL Game_CNTRL;
    GameObject DeadEnterObj;
    GameObject startPoint;
    GameObject unitychan;
    bool IsOnEnterDeadArea;

    public void MyStart()
    {
        Game_CNTRL = GetComponent<testGame_CNTRL>();
        unitychan = Game_CNTRL.unitychan;
        startPoint = Game_CNTRL.startPoint;
    }

    public void MyUpdate()
    {
        DeadEnterObj = Game_CNTRL.DeadEnterObj;
        IsOnEnterDeadArea = Game_CNTRL.IsOnEnterDeadArea;

        if(DeadEnterObj == unitychan && IsOnEnterDeadArea)
        {
            unitychan.transform.position = startPoint.transform.position;
        }
    }

}
