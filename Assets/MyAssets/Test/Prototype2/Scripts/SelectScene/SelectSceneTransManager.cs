using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using unityHelper;

public class SelectSceneTransManager : MonoBehaviour {
    
    //for Fade
    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1;
    float outTimeElapsed = 0f;
    MyFade myFade;
    //for scene trans
    public GameObject Level1ButtonObj;
    public GameObject Level2ButtonObj;
    public GameObject Level3ButtonObj;
    public GameObject TitleButtonObj;
    GameObject[] ButtonArray;
    raySceneDelegate[] sceneDelegates;
    KeyCode[] transKeyCodeArray;
    RaySceneManagement raySceneManagement;

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
        ButtonArray = new GameObject[] { Level1ButtonObj, TitleButtonObj , Level2ButtonObj, Level3ButtonObj};
        sceneDelegates = new raySceneDelegate[] { new raySceneDelegate(Level1InClick), new raySceneDelegate(TitleInClick), new raySceneDelegate(Level2InClick), new raySceneDelegate(Level3InClick) };
        transKeyCodeArray = new KeyCode[] { KeyCode.Alpha2, KeyCode.Alpha1 , KeyCode.Alpha3, KeyCode.Alpha4};
        raySceneManagement = new RaySceneManagement(ButtonArray, sceneDelegates, transKeyCodeArray);
    }

    public void MyUpdate()
    {
        myFade.MyFadeIn();
        raySceneManagement.MyUpdate();
    }

    void Level1InClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(AllScenesInfoStatic.Level1SceneName);
        }
    }
    void Level2InClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if (outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(AllScenesInfoStatic.Level2SceneName);
        }
    }
    void Level3InClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if (outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(AllScenesInfoStatic.Level3SceneName);
        }
    }
    void TitleInClick()
    {
        outTimeElapsed += Time.deltaTime;
        myFade.MyFadeOut();
        if(outTimeElapsed > transitionTime)
        {
            SceneManager.LoadScene(AllScenesInfoStatic.TitleSceneName);
        }
    }
}
