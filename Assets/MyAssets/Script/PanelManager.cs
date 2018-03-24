using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelManager : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・SelectObject内
    /// ・
    /// </summary>

    //必要な変数
    //phase
    ObjectManager_ver3 objectManager_Ver3;
    SelectObjectPhase SelectObject;
    //変数
    GameObject panelCanvas;
    Animator panelAnim;
    GameObject decideButton;
    GameObject deleteButton;

    public void MyStart()
    {
        //必要な変数
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();
        SelectObject = GetComponent<SelectObjectPhase>();
        panelCanvas = GameObject.Find("Canvas");
        panelAnim = panelCanvas.GetComponent<Animator>();
        decideButton = GameObject.Find("Canvas/objectPanel/decideButton");
        deleteButton = GameObject.Find("Canvas/objectPanel/deleteButton");

        //処理
        SetObjectPanel();
    }

    public void ToEditPhase()
    {
        //パネルの切り替え
        panelAnim.SetTrigger("toEditPhase");
    }

    public void ToSelectPhase()
    {
        panelAnim.SetTrigger("toSelectPhase");
    }

    //objectPanel
    void SetObjectPanel()
    {
        ////objectpanalのボタンに関数付与
        //int i = 0;
        //decideButton.GetComponent<Button>().onClick.AddListener(() => DecideOnClick(i));
        //deleteButton.GetComponent<Button>().onClick.AddListener(() => DeleteOnClick(i));
    }

    public void DecideOnClick()
    {
        Destroy(objectManager_Ver3.targetControllerClone);
        ToSelectPhase();
    }

    public void DeleteOnClick()
    {
        Destroy(objectManager_Ver3.target);
        ToSelectPhase();
    }
}
