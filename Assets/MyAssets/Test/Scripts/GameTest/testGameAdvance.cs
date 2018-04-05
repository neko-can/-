using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class testGameAdvance : MonoBehaviour {

    testGame_CNTRL Game_CNTRL;
    //DeadArea
    GameObject DeadEnterObj;
    GameObject startPoint;
    GameObject StartPointDirection;
    GameObject unitychan;
    bool IsOnEnterDeadArea;
    Animator unitychanAnim;
    string WaitName;
    Rigidbody unitychanRb;
    //GoalArea
    GameObject GoalEnterObj;
    bool IsOnEnterGoalArea;
    //シーン遷移
    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1f;
    MyFade myFade;
    bool IsToRecodeScene = false;
    string recodeSceneName = "Recode";
    float ClearTime;
    float outTimeElapsed = 0f;

    public void MyStart()
    {
        Game_CNTRL = GetComponent<testGame_CNTRL>();
        unitychan = Game_CNTRL.unitychan;
        startPoint = Game_CNTRL.startPoint;
        unitychanAnim = Game_CNTRL.unitychanAnim;
        WaitName = Game_CNTRL.WaitName;
        unitychanRb = unitychan.GetComponent<Rigidbody>();
        StartPointDirection = Game_CNTRL.StartPointDirection;
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
    }

    public void MyUpdate()
    {
        //シーン遷移
        myFade.MyFadeIn();

        //DeadArea
        DeadEnterObj = Game_CNTRL.DeadEnterObj;
        IsOnEnterDeadArea = Game_CNTRL.IsOnEnterDeadArea;
        if(DeadEnterObj == unitychan && IsOnEnterDeadArea)
        {
            unitychan.transform.position = startPoint.transform.position;
            unitychan.transform.forward = StartPointDirection.transform.forward;
            unitychanAnim.SetTrigger(WaitName);
            unitychanRb.velocity = Vector3.zero;
        }
        //GoalArea
        GoalEnterObj = Game_CNTRL.GoalEnterObj;
        IsOnEnterGoalArea = Game_CNTRL.IsOnEnterGoalArea;
        if(GoalEnterObj == unitychan && IsOnEnterGoalArea)
        {
            IsToRecodeScene = true;
            ClearTime = Game_CNTRL.ClearTime;
            SendData.ClearTime = ClearTime;
        }
        //TestGoal
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            IsToRecodeScene = true;
            ClearTime = Game_CNTRL.ClearTime;
            SendData.ClearTime = ClearTime;
        }
        //ToRecodeScene
        if (IsToRecodeScene)
        {
            SceneTrans();
        }
    }

    void SceneTrans()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(recodeSceneName);
        }
    }

}
