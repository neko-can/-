using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using unityHelper;

public class SelectSceneTransManager : MonoBehaviour {
    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1;
    float outTimeElapsed = 0f;
    MyFade myFade;
    public GameObject Level1ButtonObj;
    GameObject[] ButtonArray;
    raySceneDelegate[] sceneDelegates;
    KeyCode[] transKeyCodeArray;
    RaySceneManagement raySceneManagement;
    string Level1SceneName = "Level1";

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
        ButtonArray = new GameObject[] { Level1ButtonObj };
        sceneDelegates = new raySceneDelegate[] { new raySceneDelegate(Level1InClick) };
        transKeyCodeArray = new KeyCode[] { KeyCode.Alpha1 };
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
            SceneManager.LoadScene(Level1SceneName);
        }
    }
}
