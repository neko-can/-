using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneTransition : MonoBehaviour {

    //for Scene trans
    public GameObject StartButton;
    public GameObject ManualButton;
    public GameObject RecodeListButton;
    GameObject[] ButtonArray;
    raySceneDelegate[] sceneDelegates;
    KeyCode[] transKeyCodeArray;
    RaySceneManagement raySceneManagement;
    //for Fade
    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1f;
    float outTimeElapsed = 0f;
    MyFade myFade;

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
        ButtonArray = new GameObject[] { StartButton, ManualButton, RecodeListButton };
        sceneDelegates = new raySceneDelegate[] { new raySceneDelegate(StartInClick), new raySceneDelegate(ManualInClick), new raySceneDelegate(RecodeListInClick)};
        transKeyCodeArray = new KeyCode[] { KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };
        raySceneManagement = new RaySceneManagement(ButtonArray, sceneDelegates, transKeyCodeArray);

    }

    public void MyUpdate()
    {
        myFade.MyFadeIn();
        raySceneManagement.MyUpdate();
    }

    public void StartInClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(AllScenesInfoStatic.SelectSceneName);
        }
    }

    public void ManualInClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(AllScenesInfoStatic.ManualSceneName);
        }
    }

    void RecodeListInClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if (outTimeElapsed > transitionTime)
        {
            XRAdvance.NextSceneName = AllScenesInfoStatic.RecodeListSceneName;
            SceneManager.LoadScene(AllScenesInfoStatic.XRtoNotXRSceneName);
        }
    }


}
