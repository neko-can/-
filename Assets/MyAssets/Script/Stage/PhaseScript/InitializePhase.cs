using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializePhase : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・全てのPhaseで使う変数の初期化
    /// ・selectableZonesPos
    /// ・panelManager
    /// ・scrollContent
    /// ・savemap
    /// </summary>

    //必要な変数
    ObjectManager_ver3 objectManager_Ver3;
    SelectableZones selectableZones;
    SelectObjectPhase selectObjectPhase;
    PanelManager panelManager;
    SaveMap saveMap;

    public void MyStart()
    {
        //必要な変数
        objectManager_Ver3 = GetComponent<ObjectManager_ver3>();
        //phase
        selectObjectPhase = objectManager_Ver3.SelectObject;
        objectManager_Ver3.phaseDelegate = new PhaseDelegate(MyUpdate);
        //other script
        selectableZones = GetComponent<SelectableZones>();
        selectableZones.MyStart();
        panelManager = GetComponent<PanelManager>();
        objectManager_Ver3.panelManager = panelManager;
        panelManager.MyStart();
        saveMap = GetComponent<SaveMap>();
        saveMap.MyStart();
        //variable
        objectManager_Ver3.targetController = GameObject.Find("Prefabs/UI/targetControllerCanvas");
        objectManager_Ver3.targetControllerClone = GameObject.Instantiate(objectManager_Ver3.targetController);
    }

    public void MyUpdate()
    {
        objectManager_Ver3.phaseDelegate = new PhaseDelegate(selectObjectPhase.MyUpdate);
    }

}
