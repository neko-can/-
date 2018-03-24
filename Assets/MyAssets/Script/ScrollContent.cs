using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityHelper;

public delegate void MyDelegate();
public class ScrollContent : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・とりあえずボタン自動生成部分だけ
    /// ・ObjectManagerに付与→Phaseを意識する
    /// </summary>

    //補助
    public GameObject ButtonCenter;
    public static MyDelegate myDelegate;

    //必要な変数
    List<GameObject> WallPrefabs = new List<GameObject>();
    int noButton;
    GameObject ListButton;
    GameObject ListButtonClone;
    Vector2 buttonPosInit;
    Vector2 buttonPos;
    GameObject targetClone;
    //phase
    ObjectManager_ver3 objectManager_Ver3;
    //Scene内用変数
    GameObject WallParent;

    //見た目制御
    int buttonSize = 150;
    int noCulumn = 3;

    public void MyStart()
    {
        //変数用意
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();
        GetChild.getChildrenObject(GameObject.Find("/Prefabs/Walls").transform, ref WallPrefabs);
        noButton = WallPrefabs.Count;
        ListButton = GameObject.Find("Prefabs/UI/ObjectButton");
        WallParent = objectManager_Ver3.MapInScene.transform.Find("Walls").gameObject;

        //ボタン生成
        MakeButton();
    }

    void MakeButton()
    {
        //変数用意
        buttonPos = new Vector2();
        buttonPosInit = buttonPos;

        //共通機能設定

        //個別機能
        for (int i=0; i<noButton; i++)
        {
            //Button本体配置
            ListButtonClone = GameObject.Instantiate(ListButton, ButtonCenter.transform);
            ListButtonClone.SetActive(true);

            buttonPos = new Vector2(buttonPosInit.x + buttonSize * (i % noCulumn), buttonPosInit.y - buttonSize * (i / noCulumn));

            //position設定
            ListButtonClone.GetComponent<RectTransform>().anchoredPosition = buttonPos;

            //OnClick関数付与
            int ii = i + 0;
            targetClone = WallPrefabs[ii];
            ListButtonClone.GetComponent<Button>().onClick.AddListener(() => OnClick(WallPrefabs[ii]));
            ListButtonClone.transform.Find("Text").GetComponent<Text>().text = targetClone.name;
        }
    }

    public void OnClick(GameObject targetClone)
    {
        objectManager_Ver3.target = GameObject.Instantiate(targetClone, WallParent.transform);
        objectManager_Ver3.target.SetActive(true);
        objectManager_Ver3.target.transform.position = objectManager_Ver3.selectableZonesPos[objectManager_Ver3.posIndexStatic];

        //Controller配置
        if (objectManager_Ver3.targetControllerClone == null)//途中でデリートするから
        {
            objectManager_Ver3.targetControllerClone = GameObject.Instantiate(objectManager_Ver3.targetController);
        }
        objectManager_Ver3.targetControllerClone.transform.SetParent(objectManager_Ver3.target.transform);
        objectManager_Ver3.targetControllerClone.transform.localPosition = new Vector3(0, 0.1f, 0);
        objectManager_Ver3.targetControllerClone.SetActive(true);

        //panel切り替え
        objectManager_Ver3.panelManager.ToEditPhase();
    }

    void MyUpdate()
    {

    }

}
