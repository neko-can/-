using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1f;
    float outTimeElapsed = 0f;
    MyFade myFade;

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
    }

    public void MyUpdate()
    {
        myFade.MyFadeIn();

    }

    public void StartOnClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene("SelectScene");
        }
    }

    public void ManualOnClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene("Manual");
        }
    }

}
