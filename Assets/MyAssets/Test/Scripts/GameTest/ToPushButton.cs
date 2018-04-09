using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ToPushButton : MonoBehaviour {

    testGame_CNTRL game_CNTRL;
    int touchCount;
    Scene nowScene; //再読み込み用

    //TitleButton
    public GameObject TitleButton;
    public GameObject TitleTextObj;
    public Image ShowTimeImage;
    GameObject unitychan;
    GameObject MainCamera;
    Vector3 rayStartPos;
    Vector3 rayDirection;
    Ray ray;
    RaycastHit raycastHit;
    float countTime = 5f;
    string originalText;

    public void MyStart()
    {
        game_CNTRL = GetComponent<testGame_CNTRL>();
        nowScene = SceneManager.GetActiveScene();
        //TitleButton
        unitychan = game_CNTRL.unitychan;
        MainCamera = game_CNTRL.MainCamera;
        originalText = TitleTextObj.GetComponent<TextMesh>().text;
    }

    public void MyUpdate()
    {
        touchCount = Input.touchCount;
        if(touchCount == 3 || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(nowScene.name);
        }
        //TitleButton;
        ToTitle();
    }

    //見つめるとタイトルに戻る
    int layerMask = 1 << 9;
    float elapsedTime = 0f;
    float difTime;
    void ToTitle()
    {
        rayStartPos = MainCamera.transform.position;
        rayDirection = MainCamera.transform.transform.forward;
        ray = new Ray(rayStartPos, rayDirection);
        if (Physics.Raycast(ray, out raycastHit, Mathf.Infinity, layerMask))
        {
            elapsedTime += Time.deltaTime;
            ShowTimeImage.GetComponent<Image>().fillAmount = elapsedTime / countTime;
            difTime = (1f - elapsedTime / countTime) * countTime;
            TitleTextObj.GetComponent<TextMesh>().text = ((int)difTime).ToString();
            if (elapsedTime > countTime)
            {
                testGameAdvance.IsToTitle = true;
            }
        }
        else
        {
            elapsedTime = 0f;
            ShowTimeImage.GetComponent<Image>().fillAmount = 0f;
            TitleTextObj.GetComponent<TextMesh>().text = originalText;
        }
    }
}
