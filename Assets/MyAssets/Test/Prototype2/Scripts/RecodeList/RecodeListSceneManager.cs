using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RecodeListSceneManager : MonoBehaviour {

    //Fade
    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1;
    float outTimeElapsed = 0f;
    MyFade myFade;


    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
    }
    public void MyUpdate()
    {
        myFade.MyFadeIn();
        TitleInClick();
    }

    bool titleIsOnclick = false;
    public void TitleOnClick()
    {
        titleIsOnclick = true;
    }
    void TitleInClick()
    {
        if (titleIsOnclick)
        {
            outTimeElapsed += Time.deltaTime;
            myFade.MyFadeOut();
            if(outTimeElapsed > transitionTime)
            {
                SceneManager.LoadScene(AllScenesInfoStatic.TitleSceneName);
            }
        }
    }
}
