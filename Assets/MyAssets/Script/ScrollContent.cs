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
    //Scene内用変数
    GameObject WallParent;

    //見た目制御
    int buttonSize = 150;
    int noCulumn = 3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MyStart()
    {
        //変数用意
        getChild.getChildObject(GameObject.Find("/Prefabs/Walls").transform, ref WallPrefabs);
        noButton = WallPrefabs.Count;
        ListButton = GameObject.Find("Prefabs/UI/ObjectButton");
        WallParent = ObjectManager_ver3.MapInScene.transform.Find("Walls").gameObject;

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
            ListButtonClone = GameObject.Instantiate(ListButton, ButtonCenter.transform);
            ListButtonClone.SetActive(true);

            buttonPos = new Vector2(buttonPosInit.x + buttonSize * (i % noCulumn), buttonPosInit.y - buttonSize * (i / noCulumn));

            //position設定
            ListButtonClone.GetComponent<RectTransform>().anchoredPosition = buttonPos;

            //関数付与
            int ii = i + 0;
            ListButtonClone.GetComponent<Button>().onClick.AddListener(() => OnClick(WallPrefabs[ii]));
            ListButtonClone.transform.Find("Text").GetComponent<Text>().text = WallPrefabs[ii].name;
        }
    }

    void OnClick(GameObject targetClone)
    {
        ObjectManager_ver3.target = GameObject.Instantiate(targetClone, WallParent.transform);
        ObjectManager_ver3.target.SetActive(true);
    }

    public void Main()
    {

    }

    void MyUpdate()
    {

    }

}

public class setContent : PhaseClass
{
    ScrollContent scrollContent = new ScrollContent();
    List<GameObject> wallPrefabs = new List<GameObject>();
    GameObject buttonObject;

    public override void MyStart()
    {
        Debug.Log(scrollContent.ButtonCenter);
    }

    public override void OnChanged()
    {
        
    }

    public override void MyUpdate()
    {
        
    }
}