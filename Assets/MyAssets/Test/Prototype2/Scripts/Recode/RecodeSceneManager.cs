using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecodeSceneManager : MonoBehaviour {

    //for Fade
    public Color FadeColor;
    public Image FadeImage;
    MyFade myFade;
    string titleSceneName = "Title";
    float outTimeElapsed = 0f;
    float transitionTime = 1f;

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
    }
    public void MyUpdate()
    {
        myFade.MyFadeIn();
        SaveIsInClick();
        CancelIsInClick();
    }

    public void SaveIsInClick()
    {
        if (IsSaveOnClick)
        {
            outTimeElapsed += Time.deltaTime;
            myFade.MyFadeOut();
            if (outTimeElapsed > transitionTime)
            {
                SceneManager.LoadScene(AllScenesInfoStatic.TitleSceneName);
            }
        }
    }
    bool IsSaveOnClick = false;
    public void SaveIsOnClick()
    {
        IsSaveOnClick = true;
    }

    public void CancelIsInClick()
    {
        if (IsCancelOnClick)
        {
            outTimeElapsed += Time.deltaTime;
            myFade.MyFadeOut();
            if (outTimeElapsed > transitionTime)
            {
                SceneManager.LoadScene(AllScenesInfoStatic.TitleSceneName);
            }
        }
    }
    bool IsCancelOnClick = false;
    public void CancelIsOnClick()
    {
        IsCancelOnClick = true;
    }

}
