using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityHelper;

public delegate void PhaseDelegate();
public class ObjectManager_ver3 : MonoBehaviour {

    /// <summary>
    /// 機能
    /// ・大本はスクリプト間の従属関係を表すだけにしたい。
    /// </summary>

    //必要な変数
    //Phase
    public PhaseDelegate phaseDelegate;
    public InitializePhase Initialize;
    public SelectObjectPhase SelectObject;
    public EditMapPhase EditMap;
    //その他 : Script
    public PanelManager panelManager;
    //その他 : 変数
    public GameObject MapInScene;
    public int noZone;
    public List<Vector3> selectableZonesPos;
    public int posIndexStatic = 0;
    public GameObject target;
    public GameObject targetController;
    public GameObject targetControllerClone;

	// Use this for initialization
	void Start () {
        //初期値設定
        Initialize = GetComponent<InitializePhase>();
        SelectObject = GetComponent<SelectObjectPhase>();
        EditMap = GetComponent<EditMapPhase>();

        //処理
        Initialize.MyStart();
        SelectObject.MyStart();
        EditMap.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        phaseDelegate();
	}
}


