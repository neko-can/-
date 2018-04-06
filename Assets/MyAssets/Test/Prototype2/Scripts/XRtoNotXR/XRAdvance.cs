using System.Collections;
using System.Collections.Generic;
using unityHelper;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class XRAdvance : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・Skyboxのランダム設定
    /// ・カウントダウン
    /// ・Fade系
    /// </summary>

    //シーン遷移
    public List<Material> SkyBoxList;
    public Image FadeImage;
    public Color FadeColor;
    float transitionTime = 1f;
    float outElapsedTime;
    MyFade myFade;
    [HideInInspector] public static string NextSceneName = "Title";
    //カウントダウン
    float countTime = 10f;
    float elapsedTime;
    public GameObject countTextObj;

    public void MyStart()
    {
        myFade = new MyFade(FadeImage, FadeColor, transitionTime);
        elapsedTime = countTime;
        RandomSkyBox();
    }
    public void MyUpdate()
    {
        myFade.MyFadeIn();
        CountDown();
    }

    int skyListIndex = 0;
    void RandomSkyBox()
    {
        skyListIndex = Random.Range(0, SkyBoxList.Count);
        RenderSettings.skybox = SkyBoxList[skyListIndex];
    }

    void CountDown()
    {
        elapsedTime -= Time.deltaTime;
        if(elapsedTime < 0)
        {
            outElapsedTime += Time.deltaTime;
            myFade.MyFadeOut();
            if(outElapsedTime > transitionTime)
            {
                SceneManager.LoadScene(NextSceneName);
            }
        }
        else
        {
            countTextObj.GetComponent<Text>().text = ((int)elapsedTime).ToString();
        }
    }

}
