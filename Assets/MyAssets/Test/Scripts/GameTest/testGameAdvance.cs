using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class testGameAdvance : MonoBehaviour {

    testGame_CNTRL Game_CNTRL;
    //DeadArea
    GameObject DeadEnterObj;
    GameObject startPoint;
    GameObject unitychan;
    bool IsOnEnterDeadArea;
    //GoalArea
    GameObject GoalEnterObj;
    bool IsOnEnterGoalArea;
    string titleSceneName = "Title";

    public void MyStart()
    {
        Game_CNTRL = GetComponent<testGame_CNTRL>();
        unitychan = Game_CNTRL.unitychan;
        startPoint = Game_CNTRL.startPoint;
    }

    public void MyUpdate()
    {
        //DeadArea
        DeadEnterObj = Game_CNTRL.DeadEnterObj;
        IsOnEnterDeadArea = Game_CNTRL.IsOnEnterDeadArea;
        if(DeadEnterObj == unitychan && IsOnEnterDeadArea)
        {
            unitychan.transform.position = startPoint.transform.position;
        }
        //GoalArea
        GoalEnterObj = Game_CNTRL.GoalEnterObj;
        IsOnEnterGoalArea = Game_CNTRL.IsOnEnterGoalArea;
        if(GoalEnterObj == unitychan && IsOnEnterGoalArea)
        {
            SceneManager.LoadScene(titleSceneName);
        }
    }

}
