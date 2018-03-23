using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using unityHelper;

public delegate void PhaseDelegate();
public class ObjectManager_ver3 : MonoBehaviour {

    public GameObject mapInScene;
    public static GameObject MapInScene;

    public static PhaseDelegate phaseDelegate;
    public static SelectObjectPhase SelectObject = new SelectObjectPhase();
    public static EditMapPhase EditMap = new EditMapPhase();

    //helper
    public static getChild GetChild = new getChild();

    //座標操作
    public static int posIndexStatic = 0;

	// Use this for initialization
	void Start () {
        phaseDelegate = new PhaseDelegate(SelectObject.Main);
        MapInScene = mapInScene;

        SelectObject.MyStart();
        EditMap.MyStart();
	}
	
	// Update is called once per frame
	void Update () {
        phaseDelegate();
	}
}

public class SelectObjectPhase : PhaseClass
{
    List<GameObject> WallsPrefabs = new List<GameObject>();
    List<GameObject> buttonList = new List<GameObject>();
    int noObjects;
    GameObject ListButton;
    GameObject ListButtonClone;
    GameObject ScrollContent;
    int listButtonSize = 150;
    int noColumn = 3;
    Vector2 buttonPos;

    public override void MyStart()
    {
        ObjectManager_ver3.GetChild.getChildObject(GameObject.Find("/Prefabs/Walls").transform, ref WallsPrefabs); //Prefab情報取得
        ListButton = GameObject.Find("Prefabs/UI/ObjectButton");
        ListButton.GetComponent<RectTransform>().sizeDelta = new Vector2(listButtonSize, listButtonSize);
    }

    public override void OnChanged()
    {
        Debug.Log("selectOnChanged");
    }

    public override void MyUpdate()
    {
        ObjectManager_ver3.phaseDelegate = new PhaseDelegate(ObjectManager_ver3.EditMap.Main);

    }

    void setListButton()
    {
        //ボタン自動生成

        noObjects = WallsPrefabs.Count;
        for (int i = 0; i < noObjects; i++)
        {
            int ii = i + 0; //一時変数
            ListButton.GetComponent<Button>().onClick.AddListener(() => OnClick(ii));
        }
    }

    public void OnClick(int i)
    {
        //cloneTarget = GameObject.Instantiate(wallList[i], WallsParent.transform);
        //cloneTarget.transform.position = selectableZonesPos[posIndex];

        //targetObject = cloneTarget;
        //posIndex = 0;
    }

}

public class EditMapPhase : PhaseClass
{
    List<Vector3> selectableZonesPos = new List<Vector3>();
    Renderer floorRenderer;
    GameObject selectableZone;
    GameObject selectableZoneParent;
    GameObject floorInScene;
    Vector3 startPos;
    Vector3 floorBoundsSize;
    Vector3 floorCenter;
    GameObject selectableZoneClone;
    Vector2 noDivision;
    int noZone;

    GameObject targetController;
    GameObject upButton;
    GameObject downButton;
    GameObject leftButton;
    GameObject rightButton;
    public static GameObject targetObject;
    int posIndex = ObjectManager_ver3.posIndexStatic;

    public override void MyStart()
    {
        selectableZone = GameObject.Find("Prefabs/forEditMap/selectableZone");
        floorInScene = ObjectManager_ver3.MapInScene.transform.Find("Floor").GetChild(0).gameObject;
        selectableZoneParent = GameObject.Find("SelectableZoneParent");

        setSelectableZonesPos();
        makeSelectableZone();
    }

    public override void OnChanged()
    {
        Debug.Log("editOnChanged");
    }

    public override void MyUpdate()
    {
    }

    void setSelectableZonesPos()
    {
        floorRenderer = floorInScene.GetComponent<Renderer>();
        floorBoundsSize = floorRenderer.bounds.size;
        floorCenter = floorRenderer.bounds.center;

        startPos = new Vector3(-floorBoundsSize.x / 2 + 0.5f, 0, -floorBoundsSize.z / 2 + 0.5f);

        noDivision = new Vector2(floorBoundsSize.x, floorBoundsSize.z);

        noZone = (int)(noDivision.x * noDivision.y);
        for (int i = 0; i < noZone; i++)
        {
            selectableZonesPos.Add(new Vector3(startPos.x + i / (int)noDivision.x, 0, startPos.z + i % (int)noDivision.y));
        }
    }

    void makeSelectableZone()
    {
        for (int i = 0; i < noZone; i++)
        {
            selectableZoneClone = GameObject.Instantiate(selectableZone, selectableZoneParent.transform);
            selectableZoneClone.transform.position = selectableZonesPos[i];
        }
    }

    void setControllerButton()
    {
        targetController = GameObject.Find("Prefabs/UI/targetControllerCanvas");

        upButton = targetController.transform.Find("upButton").gameObject;
        leftButton = targetController.transform.Find("leftButton").gameObject;
        rightButton = targetController.transform.Find("rightButton").gameObject;
        downButton = targetController.transform.Find("downButton").gameObject;

        rightButton.GetComponent<Button>().onClick.AddListener(rightOnClick);
        leftButton.GetComponent<Button>().onClick.AddListener(leftOnClick);
        upButton.GetComponent<Button>().onClick.AddListener(upOnClick);
        downButton.GetComponent<Button>().onClick.AddListener(downOnClick);

    }
    void leftOnClick()
    {
        posIndex = (noZone + posIndex - 1) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void rightOnClick()
    {
        posIndex = (posIndex + 1) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void upOnClick()
    {
        posIndex = (noZone + posIndex - (int)noDivision.x) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }

    void downOnClick()
    {
        posIndex = (posIndex + (int)noDivision.x) % noZone;
        targetObject.transform.position = selectableZonesPos[posIndex];
    }
}


