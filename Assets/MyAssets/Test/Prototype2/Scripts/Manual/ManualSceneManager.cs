using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManualSceneManager : MonoBehaviour {

    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1f;
    float outTimeElapsed = 0f;
    MyFade myFade;
    public GameObject ToTitleButton;
    GameObject[] ButtonList;
    raySceneDelegate[] sceneDelegates;
    KeyCode[] transKeyCode;
    RaySceneManagement raySceneManagement;
    string TitleSceneName = "Title";

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
        ButtonList = new GameObject[] { ToTitleButton };
        sceneDelegates = new raySceneDelegate[] { new raySceneDelegate(TitleInClick) };
        transKeyCode = new KeyCode[] { KeyCode.Alpha1 };
        raySceneManagement = new RaySceneManagement(ButtonList, sceneDelegates, transKeyCode);
    }
    public void MyUpdate()
    {
        myFade.MyFadeIn();
        raySceneManagement.MyUpdate();
    }

    void TitleInClick()
    {
        Debug.Log("To Title");
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if (outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(TitleSceneName);
        }
    }

}
